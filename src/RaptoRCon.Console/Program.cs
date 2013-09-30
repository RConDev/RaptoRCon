using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using RaptoRCon.Dice;
using RaptoRCon.Server;
using RaptoRCon.Shared.Models;
using RaptoRCon.Sockets;

namespace RaptoRCon.Console
{
    public static class Program
    {
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var server = new RaptoRConServer();
            server.StartAsync();

            while (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.WriteLine("Exit the server pressing ESC");
            }

            server.StopAsync();
        }
    }
}
