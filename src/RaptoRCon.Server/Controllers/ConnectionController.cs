using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Http;
using RaptoRCon.Server.Config;
using RaptoRCon.Shared.Models;
using RaptoRCon.Sockets;
using System.ComponentModel.Composition;
using RaptoRCon.Server.Hosting;
using RaptoRCon.Dice.Factories;
using Microsoft.AspNet.SignalR.Client;
using Connection = RaptoRCon.Shared.Models.Connection;

namespace RaptoRCon.Server.Controllers
{
    /// <summary>
    /// The <see cref="ApiController"/> implementation responsible for publishing a RESTful API for managing 
    /// RCon-Interface connections
    /// </summary>
    /// <remarks>Currently limited to DICE RCon Protocol</remarks>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ConnectionController : RaptoRConApiControllerBase
    {
        private IHubProxy messageHubProxy;
        /// <summary>
        /// Gets or sets the <see cref="ConnectionHost"/> responsible for managing and accessing connections
        /// </summary>
        public ConnectionHost Host { get; private set; }

        /// <summary>
        /// Creates a new <see cref="ConnectionController"/> instance
        /// </summary>
        [ImportingConstructor]
        public ConnectionController(ConnectionHost host)
        {
            this.Host = host;

            
        }

        public async Task<ConnectionCreated> Post(Connection connection)
        {
            IDiceConnectionFactory connectionFactory = new DiceConnectionFactory();
            try
            {
                var diceConnection = await connectionFactory.CreateAsync(connection.Address, connection.Port, (sender, e) => {
                    MessageHubProxy.Invoke("SendMessage", e.Packet.ToString());
                });
                
                ////var socket = await socketFactory
                ////                       .CreateAndConnectAsync(connection.Address,
                ////                                              connection.Port,
                ////                                              (sender, e) => Console.WriteLine(e.DataReceived.Count()));
                this.Host.Socket = diceConnection;
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
