using Microsoft.AspNetCore.Mvc;
using ModsDudeServer.API.Endpoints.Authentication.Dtos;
using ModsDudeServer.Application.Authentication;

namespace ModsDudeServer.API.Endpoints.Authentication;

public static class AuthenticationEndpoints
{
    private const string _prefix = "/auth/";


    public static WebApplication MapAuthenticationEndpoints(this WebApplication app)
    {
        app.MapGet(_prefix + "login", Login);

        return app;
    }


    private static IResult Login([FromBody] LoginDto loginDto, [FromServices] ILoginService loginService)
    {
        LoginQuery loginQuery = new(loginDto.Username, loginDto.Password);

        string token = loginService.GetToken(loginQuery);

        return Results.Json(new
        {
            Token = token
        });
    }
}
