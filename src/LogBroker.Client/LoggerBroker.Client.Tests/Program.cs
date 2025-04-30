using LogBroker.Client.Core.Interfaces;
using LogBroker.Client.Infrastructure.Extensions;
using LogBroker.Client.Infrastructure.Imp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogBroker.Client.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogBroker();
            //services.AddScoped<ISender, Sender>();

            var servicesProvider = services.BuildServiceProvider();
            var logger = servicesProvider.GetRequiredService<ILogger>();
            
            logger.LogTrace("Hell o World");
            logger.LogTrace("Hell o World");
            logger.LogError("Erouuuu");
            Console.WriteLine("Hello, World!");
        }
    }
}
