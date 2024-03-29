﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using Tiktack.Common.Messaging;

namespace Tiktack.Email.EmailService
{
    internal class Program
    {
        private static readonly string Env;
        private static IConfigurationRoot Config { get; set; }

        static Program()
        {
            Env = Environment.GetEnvironmentVariable("PITSTOP_ENVIRONMENT");
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        static void Main(string[] args)
        {
            //get configuration
            var rabbitMQConfigSection = Config.GetSection("RabbitMQ");
            var host = rabbitMQConfigSection["Host"];
            var userName = rabbitMQConfigSection["UserName"];
            var password = rabbitMQConfigSection["Password"];

            // start Email manager
            var messageHandler = new RabbitMQMessageHandler(host, userName, password, "Email", "Auditlog", "");
            var manager = new EmailManager(messageHandler);
            manager.Start();

            if (Env == "Development")
            {
                Console.WriteLine("Email service started. Press any key to stop...");
                Console.ReadKey(true);
                manager.Stop();
            }
            else
            {
                Console.WriteLine("Email service started.");

                while (true)
                {
                    Thread.Sleep(10000);
                }
            }
        }
    }
}
