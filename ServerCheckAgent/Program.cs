using ServerCheckAgent.Helper;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Services;
using ServerCheckAgent.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServicesWindowsHelper, ServicesWindowsHelper>();
builder.Services.AddScoped<IServicesWindowsService, ServicesWindowsService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
