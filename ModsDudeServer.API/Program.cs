using ModsDudeServer.API.Endpoints.Authentication;
using ModsDudeServer.DataAccess.Module;
using ModsDudeServer.Modules.Authentication.Core;
using ModsDudeServer.Modules.Invites.Core;
using ModsDudeServer.Common.Messaging.Events;
using ModsDudeServer.Common.Messaging.Events.Events;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccess(
    builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Missing connection string 'Default'."), builder.Environment.IsDevelopment());
builder.Services.AddAuthenticationModule();
builder.Services.AddInvitesModule();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddEventHandlers(typeof(Program).Assembly);
builder.Services.AddSingleton<EventBus>();


var app = builder.Build();


using (IServiceScope scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<EventBus>()!.Publish(new TestEvent());
}


app.MapGroup("auth").MapAuthenticationEndpoints();


app.Run();
