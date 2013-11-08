using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using RaptoRCon.Games.Dice;
using RaptoRCon.Server.Config;
using RaptoRCon.Shared.Models;
using RaptoRCon.Sockets;
using System.ComponentModel.Composition;
using RaptoRCon.Server.Hosting;
using Microsoft.AspNet.SignalR.Client;
using System.Text;
using System.Linq;
using RaptoRCon.Games.Dice.Factories;
using RaptoRCon.Games;

namespace RaptoRCon.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CommandController : RaptoRConApiControllerBase
    {
        [ImportingConstructor]
        public CommandController(IConnectionHost connectionHost ) : base(connectionHost)
        {
        }

        public async Task<CommandResult> Post(Command command)
        {
            var connection = GetHostedConnection(command.ConnectionId);

            var gameCommand = new GameCommand() { Command = command.CommandString };

            await connection.Connection.SendAsync(gameCommand);

            return new CommandResult();
        }


    }
}
