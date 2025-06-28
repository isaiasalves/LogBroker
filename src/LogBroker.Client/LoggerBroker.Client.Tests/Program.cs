using LogBroker.Client.Core.Interfaces;
using LogBroker.Client.Infrastructure.Extensions;
using LogBroker.Client.Infrastructure.Imp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogBroker.Client.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogBroker();
            //services.AddScoped<ISender, Sender>();

            var servicesProvider = services.BuildServiceProvider();
            var logger = servicesProvider.GetRequiredService<ILogger>();

            logger.LogTrace("Hell o World");
            logger.LogTrace("Hell o World");
            logger.LogError("Erouuuu");
            Console.WriteLine("Hello, World!");





            //}
            //static void Main(string[] args)
            //{
            //    var services = new ServiceCollection();

            //    services.AddSingleton<IDataBaseAccess, DataBaseAccess>();

            //    services.AddScoped<IIPNFixResourceAccess>((provider) => 
            //    {
            //        var dataaccess = provider.GetService<IDataBaseAccess>();
            //        return new IPNFixResourceAccess(dataaccess!);
            //    });

            //    services.AddSingleton<IIPNProcessamentoFix>((provider) => 
            //    {
            //        var ipnFixResourceAcces = provider.GetService<IIPNFixResourceAccess>();
            //        return new IPNProcessamentoFix(ipnFixResourceAcces!);
            //    });





            //    services.AddSingleton<IClassA>((provider) => 
            //    {
            //        var ipnProcessamentoFix = provider.GetService<IIPNProcessamentoFix>();
            //        return new ClassA(ipnProcessamentoFix!);            
            //    });

            //    services.AddSingleton<IClassB>((provider) =>
            //    {
            //        var ipnProcessamentoFix = provider.GetService<IIPNProcessamentoFix>();
            //        return new ClassB(ipnProcessamentoFix!);
            //    });


            //    var servicesProvider = services.BuildServiceProvider();
            //    var classA = servicesProvider.GetRequiredService<IClassA>();
            //    var classB = servicesProvider.GetRequiredService<IClassA>();


            //    classA.Processa();
            //    classB.Processa();


            //    Console.WriteLine("Hello, World!");


            }
        }
}
