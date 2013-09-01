using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using Autofac.Integration.WebApi;
using RaptoRCon.Server.Config;
using RaptoRCon.Sockets;

namespace RaptoRCon.Server
{

    /// <summary>
    /// Implementation of <see cref="IRaptoRConServer"/>
    /// </summary>
    public class RaptoRConServer : IRaptoRConServer
    {
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
        public void Start()
        {
            var config = new HttpSelfHostConfiguration(baseAddress)
                             {
                                 DependencyResolver =
                                     new AutofacWebApiDependencyResolver(
                                     DependencyConfiguration.BuildUp())
                             };
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional});

            webApiServer = new HttpSelfHostServer(config);
            webApiServer.OpenAsync().Wait();
        }

        /// <summary>
        /// Stops the <see cref="IRaptoRConServer"/> instances and removes the api endpoint
        /// </summary>
        public void Stop()
        {
            webApiServer.CloseAsync().Wait();
        }
    }
}
