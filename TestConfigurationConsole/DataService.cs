using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestConfigurationConsole
{
    class DataService : IDataService
    {

        IConfiguration _config;

        public DataService(IConfiguration config)
        {
            _config = config;
        }
        public void Connect()
        {
            //read connection string
            string c1 = _config.GetConnectionString("C1");
            string c2 = _config.GetValue<string>("ConnectionStrings:C2");


            Console.WriteLine($"C1: {c1}");
            Console.WriteLine($"C2: {c2}");

           

        }
    }
}
