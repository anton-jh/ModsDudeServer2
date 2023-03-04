using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Authentication.Core.Services;
public class PasswordHasher : IPasswordHasher
{
    public PasswordHash GenerateHash(Password password)
    {
        return PasswordHash.From(BCrypt.Net.BCrypt.HashPassword(password.Value, BCrypt.Net.BCrypt.GenerateSalt()));
    }

    public bool VerifyPassword(Password password, PasswordHash hash)
    {
        return BCrypt.Net.BCrypt.Verify(password.Value, hash.Value);
    }
}
