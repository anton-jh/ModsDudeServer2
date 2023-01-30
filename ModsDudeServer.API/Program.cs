using ModsDudeServer.DataAccess.Module;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccess(
    builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Missing connection string 'Default'."), builder.Environment.IsDevelopment());

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();


var app = builder.Build();


app.Run();
