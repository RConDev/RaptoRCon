using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    public abstract class PlayerSubset : IPlayerSubset
    {
        public PlayerSubsetType Type { get; protected set; }

        protected PlayerSubset(PlayerSubsetType type)
        {
            this.Type = type;
        }

        public virtual IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(this.Type.ToString().ToLower());
        }
    }
}
