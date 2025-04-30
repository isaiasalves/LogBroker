using LogBroker.Client.Core.Enums;
using LogBroker.Client.Core.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace LogBroker.Client.Infrastructure.Imp
{
    public class BrokerSender(IChannel _channel) : IBrokerSender
    {
        public async void sendMessage(string message, string reoutingKey)
        {
            var body = Encoding.UTF8.GetBytes(message);
            await _channel.BasicPublishAsync(exchange: string.Empty, routingKey: reoutingKey, body: body);  
        }
    }
}
