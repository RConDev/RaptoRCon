using System;
using System.Web.Http;

using RaptoRCon.Server.Config;
using RaptoRCon.Sockets;
using System.Threading.Tasks;
using Common.Logging;
using Microsoft.Owin.Hosting;
using RaptoRCon.Server.Hosting;

namespace RaptoRCon.Server
{
    /// <summary>
    /// Implementation of <see cref="IRaptoRConServer"/>
    /// </summary>
    public class RaptoRConServer : IRaptoRConServer
    {
        private static ILog logger = LogManager.GetCurrentClassLogger();

        private readonly Uri baseAddress = new Uri("http://localhost:10505");
        //private HttpSelfHostServer webApiServer;
        private IDisposable webServer;

        /// <summary>
        /// Creates a new <see cref="RaptoRConServer"/> instance
        /// </summary>
        public RaptoRConServer() { }

        /// <summary>
        /// Gets the <see cref="Uri"/> the webApiServer listens on for api commands
        /// </summary>
        public Uri Endpoint
        {
            get { return baseAddress; }
        }

        /// <summary>
        /// Starts the <see cref="IRaptoRConServer"/> instance and initializes the endpoint 
        /// for publishing the api
        /// </summary>
        public async Task StartAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                logger.Debug("Starting Server");

                logger.Trace("Configuring Server");

                this.webServer = WebApp.Start<Startup>(baseAddress.ToString());

                logger.DebugFormat("Server started and listens on '{0}' ", baseAddress);
            });
        }

        /// <summary>
        /// Stops the <see cref="IRaptoRConServer"/> instances and removes the api endpoint
        /// </summary>
        public async Task StopAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                logger.Debug("Stopping Server");
                webServer.Dispose();
                logger.Debug("Server stopped");
            });
        }
    }
}
