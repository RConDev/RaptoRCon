using System;
using System.Collections.Generic;

namespace RaptoRCon.Games.Dice.Commands
{
    /// <summary>
    /// This is a 2-stepped hashed password process. When using this people cannot sniff your admin
    /// </summary>
    public class LoginHashedCommand : IDiceCommand
    {
        /// <summary>
        /// Gets the command name / the command on the console
        /// </summary>
        public string CommandName { get { return CommandNames.LoginHashed; } }

        /// <summary>
        /// Gets the <see cref="HexString"/> representing the generated password hash from retrieved salt <see cref="HexString"/>
        /// and the password in plain text
        /// </summary>
        public HexString PasswordHash { get; private set; }

        /// <summary>
        /// Creates a new <see cref="LoginHashedCommand"/> instance for the first step in the process to 
        /// retrieve the salt hash
        /// </summary>
        public LoginHashedCommand()
        {
        }

        /// <summary>
        /// Creates a new <see cref="LoginHashedCommand"/> instance for the second step in the process containing the 
        /// hashed password information
        /// </summary>
        /// <param name="passwordHash"></param>
        public LoginHashedCommand(HexString passwordHash)
        {
            #region Contracts

            if (passwordHash == null)
            {
                throw new ArgumentNullException("passwordHash");
            }

            #endregion

            PasswordHash = passwordHash;
        }

        /// <summary>
        /// Transforms the current instance into words for communication with the remote console 
        /// of the game server
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(CommandName);
            
            if (PasswordHash == null) yield break;
            foreach (var word in PasswordHash.ToWords())
            {
                yield return word;
            }
        }
    }
}
