using ModsDudeServer.Domain.Users;

namespace ModsDudeServer.Modules.Authentication.Core.Services;
public interface IPasswordHasher
{
    PasswordHash GenerateHash(Password password);
    bool VerifyPassword(Password password, PasswordHash hash);
}
