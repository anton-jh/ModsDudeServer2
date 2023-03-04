using ModsDudeServer.Common.Messaging.Commands;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using ModsDudeServer.Modules.Authentication.Core.Exceptions;
using ModsDudeServer.Modules.Authentication.Core.Services;
using ModsDudeServer.Modules.Invites.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Authentication.Core.Register;
public class RegisterHandler : ICommandHandler<RegisterCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IInviteClaimer _inviteClaimer;


    public RegisterHandler(ApplicationDbContext dbContext, IPasswordHasher passwordHasher, IInviteClaimer inviteClaimer)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _inviteClaimer = inviteClaimer;
    }


    public void Handle(RegisterCommand command)
    {
        if (CheckUsernameTaken(command.Username))
        {
            throw new UsernameTakenException();
        }

        User user = new(command.Username, _passwordHasher.GenerateHash(command.Password));

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        _inviteClaimer.ClaimInvite(command.InviteId, user);
    }


    private bool CheckUsernameTaken(UserName username)
    {
        return _dbContext.Users.Any(user => user.UserName == username);
    }
}
