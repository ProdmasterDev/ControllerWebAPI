using ControllerWebAPI.Operations;
using ControllerWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;

namespace ControllerWebAPI.Extensions
{
    public static class RegisterDependentServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            if (builder.Environment.IsDebug())
                LogManager.Setup().LoadConfigurationFromFile("nlog.debug.config");
            else
                LogManager.Setup().LoadConfigurationFromFile("nlog.release.config");

            //var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ControllerWebAPI.Db.ControllerAppContext>(ConfigureApplicationContextConnection);
            builder.Services.AddTransient(typeof(CheckAccess));
            builder.Services.AddTransient(typeof(Events));
            builder.Services.AddTransient(typeof(NullOperation));
            builder.Services.AddTransient(typeof(Ping));
            builder.Services.AddTransient(typeof(PowerOn));
            builder.Services.AddTransient(typeof(OperationFactory));

            builder.Logging.AddNLog();

            void ConfigureApplicationContextConnection(DbContextOptionsBuilder options)
            {
                var connectionStringName = (builder.Environment.IsDebug()) ? "Development" : "Release";
                options.UseNpgsql(builder.Configuration.GetConnectionString(connectionStringName))
                    .EnableSensitiveDataLogging();
            }
            return builder;
        }
    }
}
