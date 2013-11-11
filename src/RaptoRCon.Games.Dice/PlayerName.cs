using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// The “player name” (referred to as “Soldier name” in-game) is the persona name which the player chose when 
    /// logging in to EA Online.
    /// </summary>
    /// <remarks>The exact specification of a player name (length, valid characters, etc.) is currently unclear. </remarks>
    public class PlayerName
    {
        /// <summary>
        /// Gets the <see cref="string"/> representation of the <see cref="PlayerName"/>
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new <see cref="PlayerName"/> instance
        /// </summary>
        /// <param name="playerName"></param>
        /// <exception cref="ArgumentNullException">If the <paramref name="playerName"/> provided is NULL.</exception>
        public PlayerName(string playerName)
        {
            #region Contracts

            if (playerName == null)
            {
                throw new ArgumentNullException("playerName");
            }

            #endregion

            this.Value = playerName;
        }

        public IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(this.Value);
        }
    }
}
