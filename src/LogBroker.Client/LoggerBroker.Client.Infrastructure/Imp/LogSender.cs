using LogBroker.Client.Core.Enums;
using LogBroker.Client.Core.Helpers;
using LogBroker.Client.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LogBroker.Client.Infrastructure.Imp
{
    public class LogSender(IBrokerSender sender) : ILogSender
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    LogTrace(state!.ToString());
                    break;
                case LogLevel.Debug:
                    LogTrace(state!.ToString());
                    break;
                case LogLevel.Information:
                    LogTrace(state!.ToString());
                    break;
                case LogLevel.Warning:
                    LogTrace(state!.ToString());
                    break;
                case LogLevel.Error:
                    LogError(state!.ToString());
                    break;
                case LogLevel.Critical:
                    LogError(state!.ToString());
                    break;
                case LogLevel.None:
                    LogTrace(state!.ToString());
                    break;
                default:
                    LogTrace(state!.ToString());
                    break;
            }
        }

        public void LogError(string? message) => 
            sender.sendMessage(message!.ToString(), LogRoutingKeyResolver.Resolve(LogBrokerLevel.Error));

        public void LogTrace(string? message) =>
            sender.sendMessage(message!.ToString(), LogRoutingKeyResolver.Resolve(LogBrokerLevel.Trace));
    }
}
