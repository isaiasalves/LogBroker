using LogBroker.Client.Core.Helpers;

namespace LogBroker.Client.Core.Tests
{
    [TestClass]
    public class LogRoutingKeyResolverUnitTest
    {
        [TestMethod]
        public void Should_Return_Correct_Trace_RoutingKey()
        {
            var traceRoutingKey = "MYJIRA.LOGGER.TRACER";
            var traceRoutingKeyFromLogLevel = LogRoutingKeyResolver.Resolve(Enums.LogBrokerLevel.Trace);

            Assert.IsNotNull(traceRoutingKeyFromLogLevel);
            Assert.AreEqual(traceRoutingKey, traceRoutingKeyFromLogLevel.ToString());
        }

        [TestMethod]
        public void Should_Return_Correct_Error_RoutingKey()
        {
            var traceRoutingKey = "MYJIRA.LOGGER.ERROR";
            var traceRoutingKeyFromLogLevel = LogRoutingKeyResolver.Resolve(Enums.LogBrokerLevel.Error);

            Assert.IsNotNull(traceRoutingKeyFromLogLevel);
            Assert.AreEqual(traceRoutingKey, traceRoutingKeyFromLogLevel.ToString());
        }
    }
}