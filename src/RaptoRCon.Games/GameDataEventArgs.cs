using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaptoRCon.Games
{
    /// <summary>
    /// Implementation of <see cref="EventArgs"/> which contains an <see cref="IGameData"/> instance
    /// </summary>
    public class GameDataEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the <see cref="IGameData"/> instance provided within the <see cref="EventArgs"/>
        /// </summary>
        public IGameData GameData { get; private set; }

        /// <summary>
        /// Creates a new <see cref="GameDataEventArgs"/> instance
        /// </summary>
        /// <param name="gameData"></param>
        public GameDataEventArgs(IGameData gameData)
        {
            this.GameData = gameData;
        }
    }
}
