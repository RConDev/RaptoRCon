using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using Autofac.Integration.WebApi;
using RaptoRCon.Server.Config;
using RaptoRCon.Sockets;
using System.Threading.Tasks;
using Common.Logging;

namespace RaptoRCon.Server
{
    /// <summary>
    /// Implementation of <see cref="IRaptoRConServer"/>
    /// </summary>
    public class RaptoRConServer : IRaptoRConServer
    {
        private static ILog logger = LogManager.GetCurrentClassLogger();
 
        private readonly Uri baseAddress = new Uri("http://localhost:10505");
        private HttpSelfHostServer webApiServer;

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
            logger.Debug("Starting Server");
            
            logger.Trace("Configuring Server");
            var config = new HttpSelfHostConfiguration(baseAddress)
                             {
                                 DependencyResolver =
                                     new AutofacWebApiDependencyResolver(
                                     DependencyConfiguration.BuildUp())
                             };
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});

            logger.Trace("Instanciating HttpSelfHostServer");
            webApiServer = new HttpSelfHostServer(config);
            await webApiServer.OpenAsync();
                
            logger.DebugFormat("Server started and listens on '{0}' ", baseAddress);
        }

        /// <summary>
        /// Stops the <see cref="IRaptoRConServer"/> instances and removes the api endpoint
        /// </summary>
        public async Task StopAsync()
        {
            logger.Debug("Stopping Server");
            await webApiServer.CloseAsync();
            logger.Debug("Server stopped");
        }
    }
}
