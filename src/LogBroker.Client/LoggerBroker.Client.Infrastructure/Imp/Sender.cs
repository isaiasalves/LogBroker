using LogBroker.Client.Core.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace LogBroker.Client.Infrastructure.Imp
{
    public class Sender : ISender
    {
        private readonly IChannel _channel;
        public Sender(IChannel channel)
        {
            _channel = channel;
        }

        public async void sendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            await _channel.BasicPublishAsync(exchange: string.Empty, routingKey: "MYJIRA.LOGGER.ERROR", body: body);  
        }
    }
}
