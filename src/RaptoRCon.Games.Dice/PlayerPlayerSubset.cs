using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    public class PlayerPlayerSubset : PlayerSubset
    {
        public PlayerName PlayerName { get; private set; }

        public PlayerPlayerSubset(PlayerName playerName)
            : base(PlayerSubsetType.Player)
        {
            #region Contracts

            if (playerName == null)
            {
                throw new ArgumentNullException("playerName");
            }

            #endregion

            this.PlayerName = playerName;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords()
                .Concat(this.PlayerName.ToWords());
        }
    }
}
