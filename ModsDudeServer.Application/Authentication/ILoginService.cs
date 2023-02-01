using ModsDudeServer.Domain.Users;

namespace ModsDudeServer.Application.Authentication;
public interface ILoginService
{
    string GetToken(LoginQuery loginQuery);
}