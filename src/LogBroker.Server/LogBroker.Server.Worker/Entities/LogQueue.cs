using LogBroker.Server.Worker.Enums;
using RabbitMQ.Client;

namespace LogBroker.Server.Worker.Entities
{
    public class LogQueue
    {
        public string Name { get; set; } = string.Empty;
        public LogLevelQueueType LogLevelQueueType { get; set; }

        public LogQueue()
        {
            //Name = name ?? throw new ArgumentNullException(nameof(name));
            //LogLevelQueueType = logLevelQueueType;
        }
    }
}
