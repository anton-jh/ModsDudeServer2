using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Users;
using ModsDudeServer.Modules.Authentication.Core.Exceptions;
using ModsDudeServer.Modules.Authentication.Core.Options;
using ModsDudeServer.Modules.Authentication.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Authentication.Core.Login;
public class LoginService : ILoginService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly AuthenticationOptions _options;


    public LoginService(ApplicationDbContext dbContext, IPasswordHasher passwordHasher, IOptions<AuthenticationOptions> options)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _options = options.Value;
    }


    public string GetToken(LoginQuery loginQuery)
    {

        User? user = _dbContext.Users.Where(x => x.UserName == loginQuery.Username).FirstOrDefault();

        if (user is null)
        {
            throw new IncorrectUsernameException();
        }

        if (_passwordHasher.VerifyPassword(loginQuery.Password, user.PasswordHash) == false)
        {
            throw new IncorrectPasswordException();
        }

        return GenerateAccessToken(user.Id);
    }


    private string GenerateAccessToken(UserId userId)
    {
        SymmetricSecurityKey mySecurityKey = new(Encoding.ASCII.GetBytes(_options.Secret));

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _options.Issuer,
            Audience = _options.Audience,
            SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
