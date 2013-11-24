using RaptoRCon.Games.Dice.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice.Battlefield4
{
    public class GameConnectionFactory : IGameConnectionFactory
    {
        public GameConnectionFactory(IDiceConnectionFactory diceConnectionFactory) 
        {
            this.DiceConnectionFactory = diceConnectionFactory;
        }

        public async Task<IGameConnection> CreateAsync(IGameConnectionInfo connectionInfo)
        {
            var diceConnection = await DiceConnectionFactory.CreateAsync(connectionInfo.HostName, connectionInfo.Port, connectionInfo.Password);
            return new GameConnection(diceConnection);
        }

        public IDiceConnectionFactory DiceConnectionFactory { get; private set; }
    }
}
