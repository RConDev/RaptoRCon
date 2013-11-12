using System;
using System.Collections.Generic;
using System.Linq;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// A <see cref="Timeout"/> implementation where the duration is set via 
    /// a number of seconds
    /// </summary>
    public class SecondsTimeout : Timeout
    {
        /// <summary>
        /// Gets the number of seconds of the <see cref="Timeout"/> duration
        /// </summary>
        public uint Seconds { get; private set; }

        /// <summary>
        /// Creates a new <see cref="SecondsTimeout"/> instance
        /// </summary>
        /// <param name="seconds"></param>
        public SecondsTimeout(string seconds)
            : base(TimeoutType.Seconds)
        {
            #region Contracts

            if (seconds == null)
            {
                throw new ArgumentNullException("seconds");
            }

            #endregion

            this.Seconds = Convert.ToUInt32(seconds);
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords().Concat(SecondsToWords());
        }

        private IEnumerable<IDiceWord> SecondsToWords()
        {
            yield return new DiceWord(Convert.ToString(this.Seconds));
        }
    }
}