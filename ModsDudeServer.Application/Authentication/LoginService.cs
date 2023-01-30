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
internal class LoginService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly TokenOptions _options;


    public LoginService(ApplicationDbContext dbContext, IOptions<TokenOptions> options, UserName username, Password password)
    {
        _dbContext = dbContext;
        _options = options.Value;
    }


    public string Login(UserName username, Password password)
    {

        User? user = _dbContext.Users.Where(x => x.UserName == username).FirstOrDefault();

        if (user is null || !VerifyPassword(password, user.PasswordHash))
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
