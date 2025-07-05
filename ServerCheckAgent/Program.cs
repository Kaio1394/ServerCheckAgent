using ServerCheckAgent.Configurations;
using ServerCheckAgent.Helper;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Services;
using ServerCheckAgent.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

Startup.ConfigureServices(builder);

var app = builder.Build();

Startup.ConfigureMiddleware(app);

app.Run();
