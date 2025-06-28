using LogBroker.Server.Worker.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace LogBroker.Server.Worker
{
    public class ConsumerWorker(ILogger<ConsumerWorker> _logger, IConnection _connection) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var channel = CreateChannelAsync(stoppingToken).Result;

            while (!stoppingToken.IsCancellationRequested)
            {
                //TODO: Implementar retry policy para criação do channel, visto que pode falhar por diversos motivos (rede, servidor, etc.)
                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.ReceivedAsync += async (ch, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    await channel.BasicAckAsync(ea.DeliveryTag, false, stoppingToken);

                    _logger.LogInformation("Message Received at: {time}", DateTimeOffset.Now);
                };

                string consumerTag = await channel.BasicConsumeAsync("MYJIRA.LOGGER.ERROR", false, consumer, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task<IChannel> CreateChannelAsync(CancellationToken cancellationToken)
        {
            if (_connection.IsOpen)
            {
                //TODO: CancelationToken?
                return await _connection.CreateChannelAsync(cancellationToken: cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Connection is not open.");
            }
        }

        //TODO: BackgroundService precisa de Dispose?
    }
}
