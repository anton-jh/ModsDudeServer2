using ModsDudeServer.API.Endpoints.Authentication;
using ModsDudeServer.DataAccess.Module;
using ModsDudeServer.Modules.Authentication.Core;
using ModsDudeServer.Modules.Invites.Core;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccess(
    builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Missing connection string 'Default'."), builder.Environment.IsDevelopment());
builder.Services.AddAuthenticationModule();
builder.Services.AddInvitesModule();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();


var app = builder.Build();


app.MapGroup("auth").MapAuthenticationEndpoints();


app.Run();
