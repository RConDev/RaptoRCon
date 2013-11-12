using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    public class RoundsTimeout : Timeout
    {
        public uint Rounds { get; private set; }

        public RoundsTimeout(string rounds)
            :base(TimeoutType.Rounds)
        {
            #region Contracts

            if (rounds == null)
            {
                throw new ArgumentNullException("rounds");
            }

            #endregion

            this.Rounds = Convert.ToUInt32(rounds);
        }
        
        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords().Concat(RoundsToWords());
        }

        private IEnumerable<IDiceWord> RoundsToWords()
        {
            yield return new DiceWord(Convert.ToString(this.Rounds));
        } 
    }
}
