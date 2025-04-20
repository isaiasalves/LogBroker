using LogBroker.Client.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace LogBroker.Client.Infrastructure.Imp
{
    public class LogWriter(ISender sender) : ILogWriter
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    LogTrace(state.ToString());
                    break;
                case LogLevel.Debug:
                    break;
                case LogLevel.Information:
                    break;
                case LogLevel.Warning:
                    break;
                case LogLevel.Error:
                    break;
                case LogLevel.Critical:
                    break;
                case LogLevel.None:
                    break;
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogTrace(string message)
        {
            sender.sendMessage(message.ToString());
        }
    }
}
