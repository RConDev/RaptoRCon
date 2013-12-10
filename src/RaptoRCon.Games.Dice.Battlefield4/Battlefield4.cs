using RaptoRCon.Games.Dice.Factories;
using System;
using System.ComponentModel.Composition;

namespace RaptoRCon.Games.Dice.Battlefield4
{
    /// <summary>
    /// <see cref="IGame"/> implementation for Battlefield 4
    /// </summary>
    [Export(typeof(IGame))]
    public class Battlefield4 : GameBase
    {
        public static readonly Guid GameId = new Guid("EF9AB333-4AA7-488C-A6BF-FA5E5E3357C1");
        public static readonly string GameName = "Battlefield 4";
        public static readonly Uri GameHomepage = new Uri("http://www.battlefield.com/battlefield-4");

        /// <summary>
        /// Creates a new <see cref="Battlefield4"/> instance
        /// </summary>
        public Battlefield4()
            : base(GameId, GameName, GameHomepage)
        {
        }

        public override IGameConnectionFactory ConnectionFactory
        {
            get { return new GameConnectionFactory(new DiceConnectionFactory()); }
        }
    }
}
