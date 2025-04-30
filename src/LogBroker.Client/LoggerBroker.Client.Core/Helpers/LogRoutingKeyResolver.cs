using LogBroker.Client.Core.Enums;

namespace LogBroker.Client.Core.Helpers
{
    public static class LogRoutingKeyResolver
    {
        public static string Resolve(LogBrokerLevel logLevel) =>
            logLevel switch
            {
                LogBrokerLevel.Trace => "MYJIRA.LOGGER.TRACER",
                LogBrokerLevel.Error => "MYJIRA.LOGGER.ERROR",
                _ => throw new NotImplementedException()
            };

    }
}
