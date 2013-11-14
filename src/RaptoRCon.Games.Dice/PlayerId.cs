using System;
using System.Collections.Generic;

namespace RaptoRCon.Games.Dice
{
    public abstract class PlayerId : IPlayerId
    {
        public IdType Type { get; private set; }

        protected PlayerId(IdType type)
        {
            this.Type = type;
        }

        public virtual IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(Convert.ToString(this.Type).ToLower());
        }
    }
}
