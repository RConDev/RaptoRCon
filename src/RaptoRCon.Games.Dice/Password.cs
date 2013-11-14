using System;
using System.Collections.Generic;
using System.Linq;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// A password is from 0 up to 16 characters in length, inclusive. 
    /// </summary>
    /// <remarks>The allowed characters are: abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789</remarks>
    public class Password : IDiceWordifyable
    {
        /// <summary>
        /// The collection of allowed characters in the <see cref="Password.Value"/>
        /// </summary>
        public static readonly string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// Gets the string representation of the <see cref="Password"/>
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new <see cref="Password"/> instance
        /// </summary>
        /// <param name="password">The string value of the <see cref="Password"/></param>
        /// <exception cref="ArgumentNullException">If the <paramref name="password"/> provided is NULL.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="password"/> exceeds the length of 16.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="password"/> contains invalid characters.</exception>
        public Password(string password)
        {
            #region Contracts

            if (password == null)
            {
                throw new ArgumentNullException();
            }

            if (password.Length > 16)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (password.Any(character => !AllowedCharacters.Contains(character)) )
            {
                throw new ArgumentOutOfRangeException();
            }

            #endregion

            this.Value = password;
        }

        /// <summary>
        /// Transforms the current instance into words for communication with the remote console 
        /// of the game server
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(this.Value);
        }
    }
}
