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
            logger.Debug("Starting RaptoRConServer");
            var server = new RaptoRConServer();
            server.Start();
            logger.DebugFormat("RaptoRConServer is started and listens on {0}", server.Endpoint);

            ////var httpClient = new HttpClient()
            ////                     {
            ////                         BaseAddress = server.Endpoint
            ////                     };

            ////httpClient.PostAsJsonAsync("/api/connection", new Connection() {Address = "127.0.0.1", Port = 11000})
            ////          .ContinueWith(
            ////              async postTask => System.Console.WriteLine(await postTask.Result.Content.ReadAsStringAsync()))
            ////          .ContinueWith((logTask) =>
            ////                            {
            ////                                var command = new Command() {CommandString = "version"};
            ////                                httpClient.PostAsJsonAsync("/api/command", command);
            ////                            });
            

            System.Console.ReadLine();
            server.Stop();
        }
    }
}
