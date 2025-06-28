using LogBroker.Server.Worker.Extensions;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LogBroker.Server.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            // Configure Serilog using the configuration file
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


            builder.Services.AddLogBroker(configuration);
            builder.Services.AddHostedService<ConsumerWorker>();

            var host = builder.Build();
            
            host.Run();
        }
    }
}