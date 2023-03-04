using ModsDudeServer.Domain.Users;

namespace ModsDudeServer.Modules.Authentication.Core.Login;
public interface ILoginService
{
    string GetToken(LoginQuery loginQuery);
}