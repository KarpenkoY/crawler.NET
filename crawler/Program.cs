using System;
using System.Linq;
using System.Net;
using Crawler.Library;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Crawler
{
    public class Program
    {
        static Settings Settings { get; set; }

        static void Main(string[] args)
        {
            InitializeSettings();

            var crawler = new Crawler(Settings);

            try
            {
                crawler.Run();
            }
            catch
            {
                Console.WriteLine("Something went wrong. Crawler stopped");
            }

            foreach (var s in Settings.Connection.Urls)
            {
                Console.WriteLine(s);
            }
        }

        private static void InitializeSettings()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var settings = new Settings();
            builder.Build().Bind(settings);
            Settings = settings;
        }
    }
}
