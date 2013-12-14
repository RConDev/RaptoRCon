using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice
{
    public class PlayerPlayerSubset : PlayerSubset
    {
        public PlayerName PlayerName { get; private set; }

        public PlayerPlayerSubset(PlayerName playerName)
            : base(PlayerSubsetType.Player)
        {
            Guard.That(() => playerName).IsNotNull();
            
            PlayerName = playerName;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords()
                .Concat(this.PlayerName.ToWords());
        }
    }
}
