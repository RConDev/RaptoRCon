using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// An integer. Team 0 is neutral.
    /// </summary>
    /// <remarks>Depending on gamemode, there are up to 16 non-neutral teams, numbered 1…16.</remarks>
    public class TeamId
    {
        /// <summary>
        /// Gets the <see cref="Int32"/> Team-ID value
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Gets the sign, if the current team id is neutral
        /// </summary>
        public bool IsNeutral { get { return this.Value == 0; } }

        /// <summary>
        /// Creates a new <see cref="TeamId"/> instance
        /// </summary>
        /// <param name="teamId"></param>
        /// <exception cref="ArgumentNullException">If the <paramref name="teamId"/> provided is NULL.</exception>
        public TeamId(string teamId)
        {
            #region Contracts

            if (teamId == null)
            {
                throw new ArgumentNullException("teamId");
            }

            var intValue = 0;
            if (!Int32.TryParse(teamId, out intValue))
            {
                throw new ArgumentOutOfRangeException("teamId");
            }

            if (intValue < 0 || intValue > 16)
            {
                throw new ArgumentOutOfRangeException("teamId");
            }

            #endregion

            this.Value = intValue;
        }
    }
}
