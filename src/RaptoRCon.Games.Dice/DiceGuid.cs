using System;
using System.Collections.Generic;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// The <see cref="DiceGuid"/> is a unique identifier for a player. 
    /// </summary>
    /// <remarks>It is 35 characters long, consists of the prefix “EA_” immediately followed by a 32-character HexString.</remarks>
    public class DiceGuid : IDiceWordifyable
    {
        /// <summary>
        /// Gets the <see cref="string"/> representation of the <see cref="DiceGuid"/>
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new <see cref="DiceGuid"/> instance
        /// </summary>
        /// <param name="guid">The <see cref="string"/> representation of the <see cref="DiceGuid"/></param>
        /// <exception cref="ArgumentNullException">If the <paramref name="guid"/> provided is NULL.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="guid"/> is not exactly 35 characters long.</exception>
        public DiceGuid(string guid)
        {
            #region Contracts

            if (guid == null) 
            {
                throw new ArgumentNullException();
            }

            if (guid.Length != 35)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!guid.StartsWith("EA_"))
            {
                throw new ArgumentOutOfRangeException();
            }

            #endregion

            this.Value = guid;
        }

        public IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(Value);
        }
    }
}
