namespace RaptoRCon.Games.Dice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// this class represents a complete string which stands for an DICE RCon Command
    /// </summary>
    public class DiceCommandString : IDiceWordifyable
    {
        private const string SplitChar = " ";

        private const string Quote = "\"";

        private readonly string commandString;

        /// <summary>
        /// creates a new <see cref="DiceCommandString"/> instance for a <see cref="string"/>
        /// </summary>
        /// <param name="commandString"></param>
        public DiceCommandString(string commandString)
        {
            this.commandString = commandString;
        }

        /// <summary>
        /// Transforms the current instance into words for communication with the remote console 
        /// of the game server
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDiceWord> ToWords()
        {
            string[] parts = commandString.Split(SplitChar.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            return EnsureQuoted(parts).Select(x => new DiceWord(x));
        }

        private IEnumerable<string> EnsureQuoted(IEnumerable<string> parts)
        {
            if (!commandString.Contains(Quote))
            {
                return parts;
            }

            List<string> partsList = parts.ToList();
            var resultParts = new List<string>();
            var currentPart = new StringBuilder();
            foreach (var part in partsList)
            {
                if (part.StartsWith(Quote))
                {
                    currentPart.Append(part.Replace(Quote, string.Empty))
                               .Append(SplitChar);
                }
                else if (part.EndsWith(Quote))
                {
                    currentPart.Append(part.Replace(Quote, string.Empty));
                    resultParts.Add(currentPart.ToString());
                    currentPart = new StringBuilder();
                }
                else if (currentPart.Length == 0)
                {
                    resultParts.Add(part);
                }
                else if (currentPart.Length > 0)
                {
                    currentPart.Append(part)
                               .Append(SplitChar);
                }
            }

            return resultParts;
        }
    }
}