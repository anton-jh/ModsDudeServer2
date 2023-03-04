using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Authentication.Core.Services;
public interface IUserFactory
{
    public User Get(ClaimsPrincipal claimsPrincipal);
}
