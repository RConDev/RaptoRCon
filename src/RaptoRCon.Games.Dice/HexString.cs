using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// A stream of hexadecimal digits. The stream must always contain an even number of digits. 
    /// </summary>
    /// <remarks>Allowed characters are: 0123456789ABCDEF</remarks>
    public class HexString
    {
        /// <summary>
        /// The collection of allowed characters in a <see cref="HexString"/>
        /// </summary>
        public static readonly string AllowedCharacters = "0123456789ABCDEF";

        /// <summary>
        /// Gets the string representation of the <see cref="HexString"/>
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new <see cref="HexString"/> instance
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException">If the value provided contains not allowed characters</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the number of characters in the value is not even.</exception>
        public HexString(string value)
        {
            var upperValue = value.ToUpper();

            #region Contracts

            if (upperValue.Any(character => !AllowedCharacters.Contains(character))) 
            {
                throw new ArgumentOutOfRangeException();
            }

            if (upperValue.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            #endregion

            this.Value = upperValue;
        }
    }
}
