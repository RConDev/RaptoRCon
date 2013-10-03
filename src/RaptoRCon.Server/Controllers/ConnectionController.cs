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
        /// <summary>
        /// Creates a new <see cref="ConnectionController"/> instance
        /// </summary>
        [ImportingConstructor]
        public ConnectionController(ConnectionHost host) : base (host)
        {
        }

        public async Task<IEnumerable<Connection>> Get() 
        {
            return this.ConnectionHost.Get().Select(x => new Connection() { Id = x.Id, HostName = x.HostName, Port = x.Port });
        }

        public async Task<ConnectionCreated> Post(Connection connection)
        {
            IDiceConnectionFactory connectionFactory = new DiceConnectionFactory();
            try
            {
                var diceConnection = await connectionFactory.CreateAsync(connection.HostName, connection.Port);
                var hostedConnection = new HostedConnection(connection.HostName, connection.Port, diceConnection);
                diceConnection.PacketReceived += (sender, e) =>
                {
                    MessageHubProxy.Invoke("SendMessage", hostedConnection.Id, e.Packet.ToString());
                };

                this.ConnectionHost.Add(hostedConnection);
                return new ConnectionCreated(hostedConnection.Id, connection);
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
