using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Crawler
{
    internal class Crawler
    {
        private Settings Settings { get; set; }

        public Crawler(Settings settings)
        {
            Settings = settings;
        }

        public void Run()
        {
            CheckInternetConnection();
        }

        private void CheckInternetConnection()
        {
            while (InternetConnectionIsUnvaible())
            {
                Console.Clear();
                Console.Write("Internet connection is unavailable. Press ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('x');
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(" for exit. Press any other key for try again.\n");

                char answer = Console.ReadKey().KeyChar;
                if (answer == 'x')
                {
                    Console.Clear();
                    Environment.Exit(1);
                }
            }
            Console.Clear();
        }

        private bool InternetConnectionIsUnvaible()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead(Settings.Connection.Urls.FirstOrDefault()))
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}
