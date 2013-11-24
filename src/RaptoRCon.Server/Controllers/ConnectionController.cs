using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RaptoRCon.Shared.Models;
using System.ComponentModel.Composition;
using RaptoRCon.Server.Hosting;
using Connection = RaptoRCon.Shared.Models.Connection;
using RaptoRCon.Shared.Commands;
using RaptoRCon.Games;

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
        public ConnectionController(IConnectionHost connectionHost)
            : base(connectionHost)
        {
        }

        /// <summary>
        /// Gets all active <see cref="Connection"/>s
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Connection>> Get()
        {
            return await Task.Factory.StartNew(
                () =>
                {
                    var connections = ConnectionHost.Get();
                    return connections.Select(
                        x => new Connection()
                             {
                                 Id = x.Id,
                                 HostName = x.HostName,
                                 Port = x.Port,
                                 State = x.Connection.State
                             });
                });
        }

        [HttpPost]
        public async Task<ConnectionCreated> Create(CreateConnectionCommand createConnection)
        {
            try
            {
                var game = await GamesContext.GetInstance().GetAsync(createConnection.GameId);
                if (game != null)
                {
                    var gameConnectionInfo = new GameConnectionInfo
                                             {
                                                 HostName = createConnection.HostName,
                                                 Port = createConnection.Port,
                                                 Password = createConnection.Password,
                                             };
                    var gameConnection = await game.ConnectionFactory.CreateAsync(gameConnectionInfo);

                    var hostedConnection = new HostedConnection(createConnection.HostName, createConnection.Port, gameConnection);
                    gameConnection.GameDataReceived += (sender, e) => MessageHubProxy.Invoke("SendMessage", hostedConnection.Id, e.GameData.DataString);
                    this.ConnectionHost.Add(hostedConnection);
                    await hostedConnection.ConnectAsync();

                    var connection = new Connection()
                    {
                        Id = hostedConnection.Id,
                        HostName = createConnection.HostName,
                        Port = createConnection.Port,
                        State = hostedConnection.Connection.State
                    };

                    return new ConnectionCreated(hostedConnection.Id, connection);
                }

                var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(string.Format("Game with id '{0}' was not found.", createConnection.GameId)),
                };
                throw new HttpResponseException(responseMessage);
            }
            catch (Exception ex)
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict)
                                          {
                                              Content = new StringContent(ex.Message),
                                          };
                throw new HttpResponseException(responseMessage);
            }
        }

        [HttpDelete]
        public async Task<bool> Delete(Guid id)
        {
            return await Task.Factory.StartNew(() =>
            {
                var hostedConnection = ConnectionHost.Get(id);
                return ConnectionHost.Remove(hostedConnection);
            });
        }

        [HttpGet]
        [Route("api/connection/{connectionId}/disconnect")]
        public async Task<Connection> Disconnect(Guid connectionId)
        {
            var hostedConnection = this.ConnectionHost.Get(connectionId);
            await hostedConnection.DisconnectAsync();
            return new Connection
                   {
                       Id = hostedConnection.Id,
                       HostName = hostedConnection.HostName,
                       Port = hostedConnection.Port,
                       State = hostedConnection.Connection.State
                   };
        }

        [HttpGet]
        [Route("api/connection/{connectionId}/connect")]
        public async Task<Connection> Connect(Guid connectionId)
        {
            var hostedConnection = this.ConnectionHost.Get(connectionId);
            await hostedConnection.ConnectAsync();
            return new Connection
                   {
                       Id = hostedConnection.Id,
                       HostName = hostedConnection.HostName,
                       Port = hostedConnection.Port,
                       State = hostedConnection.Connection.State
                   };
        }
    }
}
