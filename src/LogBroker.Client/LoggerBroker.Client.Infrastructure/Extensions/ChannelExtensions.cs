using LogBroker.Client.Core.Interfaces;
using LogBroker.Client.Infrastructure.Imp;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace LogBroker.Client.Infrastructure.Extensions
{
    public static class ChannelExtensions
    {
        public static IServiceCollection AddLogBroker(this IServiceCollection services)
        {
            var factory = new ConnectionFactory { 
                HostName = "localhost" ,
                UserName = "admin" ,
                Password = "admin",
                VirtualHost = "MyJira"
            };


            services.AddScoped(chn =>
            {
                IConnection connection = factory.CreateConnectionAsync().Result;

                var channel = connection.CreateChannelAsync().Result;

                channel.ExchangeDeclareAsync(exchange: "MYJIRA.LOGGER", type: ExchangeType.Direct, durable: false, autoDelete: false, arguments: null);
                
                channel.QueueDeclareAsync(queue: "MYJIRA.LOGGER.ERROR", durable: false, exclusive: false, autoDelete: false,
                arguments: null);

                channel.QueueDeclareAsync(queue: "MYJIRA.LOGGER.TRACER", durable: false, exclusive: false, autoDelete: false,
                arguments: null);

                return channel;
            });


            services.AddScoped<IBrokerSender, BrokerSender>();
            services.AddLogger();

            return services;
        }
    }

    //TODO: Implementar logs via Event Viewer ou outra forma, visto que se o Client falhar, não será possível enviar mensagens para o Broker
    //TODO: Carregar parâmetros como nome de fila, usuário, senha, e outras configurações  a partir do appsettings.json
}
