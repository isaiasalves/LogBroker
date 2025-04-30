using LogBroker.Client.Infrastructure.Imp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogBroker.Client.Infrastructure.Extensions
{
    public static class LoggerExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            services.AddScoped<ILogger, LogSender>();

            return services;
        }
    }
}
