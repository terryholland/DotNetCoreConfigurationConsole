using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace TestConfigurationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = AppStartup();
            var dataservice = ActivatorUtilities.CreateInstance<DataService>(host.Services);

            dataservice.Connect();
            Console.ReadLine();
        }

        static void ConfigSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

        }

        static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            ConfigSetup(builder);


            //initialise the DI container (dotnet in built)
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context,services)=>
                {
                    //Add transient: new instance each time requested
                    services.AddTransient<IDataService, DataService>();
                })
               .Build();

            return host;


        }
       
    }
}
