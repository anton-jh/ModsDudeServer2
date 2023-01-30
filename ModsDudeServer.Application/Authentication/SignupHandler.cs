using ModsDudeServer.Application.Authentication.Exceptions;
using ModsDudeServer.Application.Commands;
using ModsDudeServer.Application.Invites;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Authentication;
public class SignupHandler : ICommandHandler<SignupCommand>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICommandHandler<ClaimRepoInviteCommand> _claimInviteHandler;


    public SignupHandler(ApplicationDbContext dbContext, ICommandHandler<ClaimRepoInviteCommand> claimInviteHandler)
    {
        _dbContext = dbContext;
        _claimInviteHandler = claimInviteHandler;
    }


    public void Handle(SignupCommand command)
    {
        if (CheckUsernameTaken(command.Username))
        {
            throw new UsernameTakenException();
        }

        User user = new(command.Username, HashPassword(command.Password));

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        _claimInviteHandler.Handle(new(command.RepoInviteId.Value));
    }


    private bool CheckUsernameTaken(UserName username)
    {
        return _dbContext.Users.Any(user => user.UserName == username);
    }


    private static PasswordHash HashPassword(Password password)
    {
        return PasswordHash.From(BCrypt.Net.BCrypt.HashPassword(password.Value, BCrypt.Net.BCrypt.GenerateSalt()));
    }
}
