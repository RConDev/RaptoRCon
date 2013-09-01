using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using RaptoRCon.Server.Config;
using RaptoRCon.Shared.Models;
using RaptoRCon.Sockets;

namespace RaptoRCon.Server.Controllers
{
    /// <summary>
    /// The <see cref="ApiController"/> implementation responsible for publishing a RESTful API for managing 
    /// RCon-Interface connections
    /// </summary>
    /// <remarks>Currently limited to DICE RCon Protocol</remarks>
    public class ConnectionController : ApiController
    {
        /// <summary>
        /// Gets or sets the <see cref="ConnectionHost"/> responsible for managing and accessing connections
        /// </summary>
        public ConnectionHost Host { get; private set; }

        /// <summary>
        /// Creates a new <see cref="ConnectionController"/> instance
        /// </summary>
        public ConnectionController()
        {
            this.Host = new ConnectionHost();
        }

        public async Task<ConnectionCreated> Post(Connection connection)
        {
            ISocketFactory socketFactory = new SocketFactory();
            try
            {
                var socket = await socketFactory
                                       .CreateAndConnectAsync(connection.Address,
                                                              connection.Port,
                                                              (sender, e) => Console.WriteLine(e.DataReceived.Count()));
                return new ConnectionCreated(connection);
            }
            catch (Exception ex)
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict)
                                          {
                                              Content = new StringContent(ex.Message)
                                          };
                throw new HttpResponseException(responseMessage);
            }
        }
    }
}
