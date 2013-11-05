using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice.Battlefield4
{
    public class Battlefield4 : GameBase
    {
        public static readonly Guid GameId = new Guid("EF9AB333-4AA7-488C-A6BF-FA5E5E3357C1");
        public static readonly string GameName = "Battlefield 4";
        public static readonly Uri GameHomepage = new Uri("http://www.battlefield.com/battlefield-4");

        public Battlefield4()
            : base(GameId, GameName, GameHomepage)
        {
        }

        public override IGameConnectionFactory ConnectionFactory
        {
            get { throw new NotImplementedException(); }
        }
    }
}
