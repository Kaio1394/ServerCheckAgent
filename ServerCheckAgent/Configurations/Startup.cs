using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Helper;
using ServerCheckAgent.Services.Interfaces;
using ServerCheckAgent.Services;
using Hardware.Info;

namespace ServerCheckAgent.Configurations
{
    public static class Startup
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IServicesWindowsHelper, ServicesWindowsHelper>();
            builder.Services.AddScoped<IServicesWindowsService, ServicesWindowsService>();
            builder.Services.AddScoped<IEventViewerHelper, EventViewerHelper>();
            builder.Services.AddScoped<IProcessHelper, ProcessHelper>();
            builder.Services.AddScoped<IProcessService, ProcessService>();
            builder.Services.AddScoped<IEventViewService, EventViewService>();
            builder.Services.AddScoped<IScriptsHelper, ScriptsHelper>();
            builder.Services.AddScoped<IScriptsService, ScriptsService>();
            builder.Services.AddScoped<IHardwareInfoHelper, HardwareInfoHelper>();
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IHardwareInfo, HardwareInfo>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
        public static void ConfigureMiddleware(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowAll");
        }
    }
}
