using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModsDudeServer.Application.Authentication.Exceptions;
using ModsDudeServer.DataAccess;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Authentication;
public class LoginService : ILoginService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly AuthenticationOptions _options;


    public LoginService(ApplicationDbContext dbContext, IOptions<AuthenticationOptions> options)
    {
        _dbContext = dbContext;
        _options = options.Value;
    }


    public string GetToken(LoginQuery loginQuery)
    {

        User? user = _dbContext.Users.Where(x => x.UserName == loginQuery.Username).FirstOrDefault();

        if (user is null)
        {
            throw new IncorrectUsernameException();
        }

        if (!VerifyPassword(loginQuery.Password, user.PasswordHash))
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


    private static bool VerifyPassword(Password password, PasswordHash hash)
    {
        return BCrypt.Net.BCrypt.Verify(password.Value, hash.Value);
    }
}
