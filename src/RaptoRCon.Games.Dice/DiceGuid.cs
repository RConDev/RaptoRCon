using System;
using System.Collections.Generic;
using Seterlund.CodeGuard;

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
            Guard.That(() => guid).IsNotNull().Length(35).StartsWith("EA_");

            Value = guid;
        }

        public IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(Value);
        }
    }
}
