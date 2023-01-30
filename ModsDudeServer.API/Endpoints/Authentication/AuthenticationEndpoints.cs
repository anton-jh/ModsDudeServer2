using Microsoft.AspNetCore.Mvc;
using ModsDudeServer.API.Endpoints.Authentication.Dtos;
using ModsDudeServer.Application.Authentication;

namespace ModsDudeServer.API.Endpoints.Authentication;

public static class AuthenticationEndpoints
{
    public static RouteGroupBuilder MapAuthenticationEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("login", Login);

        return group;
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
