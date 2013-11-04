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
using RaptoRCon.Games.Dice.Factories;
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
        /// <param name="connectionHost">The <see cref="IConnectionHost"/> instance which holds all connections</param>
        [ImportingConstructor]
        public ConnectionController(IConnectionHost connectionHost) : base (connectionHost)
        {
        }

        /// <summary>
        /// Gets all active <see cref="Connection"/>s
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Connection>> Get() 
        {
            return this.ConnectionHost.Get().Select(x => new Connection() { Id = x.Id, HostName = x.HostName, Port = x.Port });
        }

        [HttpPost]
        public async Task<ConnectionCreated> Add(Connection connection)
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

        [HttpDelete]
        public async Task<bool> Delete(Guid id)
        {
            var hostedConnection = ConnectionHost.Get(id);
            return ConnectionHost.Remove(hostedConnection);
        }
    }
}
