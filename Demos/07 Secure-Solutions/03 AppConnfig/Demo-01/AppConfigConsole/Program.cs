using System;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace AppConfigConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var permissions = false;
            var builder = new ConfigurationBuilder();
            var cs = Environment.GetEnvironmentVariable("AppConfigCS");

            if (permissions)
            {
                builder.AddAzureAppConfiguration(cs);
                var config = builder.Build();
                var title = config["Settings:Title"];
                Console.WriteLine(title ?? "No Title received");
            }
            else
            {
                builder.AddAzureAppConfiguration(options =>
               {
                   options.Connect(cs)
                           .ConfigureKeyVault(kv =>
                           {
                               kv.SetCredential(new DefaultAzureCredential());
                           });
               });

                var config = builder.Build();
                Console.WriteLine(config["Settings:Title"] ?? "No Title received");
                Console.WriteLine(config["Data:SQL"] ?? "No ConString received");
            }
        }
    }
}