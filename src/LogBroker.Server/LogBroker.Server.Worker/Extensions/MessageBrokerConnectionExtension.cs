using RabbitMQ.Client;

namespace LogBroker.Server.Worker.Extensions
{
    public static class MessageBrokerConnectionExtension
    {
        public static async Task<IServiceCollection> AddLogBroker(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services);

            var connFactory = new ConnectionFactory();
            connFactory.AutomaticRecoveryEnabled = true; // Habilita a recuperação automática da conexão

            configuration.GetSection("RabbitMQ").Bind(connFactory);

            try
            {
                //Ainda não achei uma solução para usar o ConnectionFactory de forma assíncrona. A conexão é criada de forma síncrona aqui, como
                //esse método é chamado apenas uma vez na inicialização do Worker, não vejo problema em usar o GetAwaiter().GetResult()
                IConnection connection = connFactory.CreateConnectionAsync().GetAwaiter().GetResult();

                services.AddSingleton<IConnection>(serviceProvider =>
                {
                    return connection;
                });
            }
            catch (Exception)
            {
                await Task.Delay(1000); // Espera 1 segundo antes de tentar novamente
            }

            return services;
        }
    }

    //TODO: Implementar resilience e retry policies para conexão com o RabbitMQ, visto que a conexão pode falhar por diversos motivos (rede, servidor, etc.)
    //TODO: Implementar logs via Event Viewer ou outra forma, visto que se o Client falhar, não será possível enviar mensagens para o Broker
    //TODO: Carregar parâmetros como nome de fila, usuário, senha, e outras configurações  a partir do appsettings.json
}
