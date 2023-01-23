using ModsDudeServer.DataAccess.Module;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccess(
    builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Missing connection string 'Default'."), builder.Environment.IsDevelopment());


var app = builder.Build();


app.Run();
