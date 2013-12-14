using System;
using System.Collections.Generic;
using System.Linq;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice
{
    public class NamePlayerId : PlayerId
    {
        /// <summary>
        /// Gets the Name of the identifiable Player
        /// </summary>
        public PlayerName Name { get; private set; }

        /// <summary>
        /// Creates a new <see cref="NamePlayerId"/> instance
        /// </summary>
        /// <param name="playerName"></param>
        public NamePlayerId(PlayerName playerName)
            :base(IdType.Name)
        {
            Guard.That(() => playerName).IsNotNull();

            Name = playerName;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords().Concat(this.Name.ToWords());
        }
    }
}