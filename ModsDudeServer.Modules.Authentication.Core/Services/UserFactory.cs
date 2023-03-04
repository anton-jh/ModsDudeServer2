using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Users;
using ModsDudeServer.Modules.Authentication.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Authentication.Core.Services;
public class UserFactory : IUserFactory
{
    private readonly ApplicationDbContext _dbContext;

    private User? _cachedUser;


    public UserFactory(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public User Get(ClaimsPrincipal claimsPrincipal)
    {
        if (_cachedUser is not null)
        {
            return _cachedUser;
        }

        string? userIdString = claimsPrincipal.Identity?.Name;

        if (Guid.TryParse(userIdString, out Guid userIdGuid) == false)
        {
            throw new NotAuthenticatedException();
        }

        UserId userId = UserId.From(userIdGuid);

        User? user = _dbContext.Users.Find(userId);

        if (user is null)
        {
            throw new NotAuthenticatedException();
        }

        _cachedUser = user;

        return user;
    }
}
