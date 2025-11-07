using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using KonekLogicProcess;

namespace KonekGUI
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // Load appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Create EmailService instance with configuration
            var emailService = new EmailServices(config);

            // Pass EmailService into KonekService
            var konekService = new KonekService(emailService);

            ApplicationConfiguration.Initialize();
            Application.Run(new Login(konekService));
        }
    }
}