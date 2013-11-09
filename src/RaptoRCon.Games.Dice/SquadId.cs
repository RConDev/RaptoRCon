using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// An integer.
    /// Squad 0 is “no squad”. Depending on gamemode, there are up to 32 squads numbered 1…32. 
    /// Note that squad IDs are local within each team; that is, to uniquely identify a squad you 
    /// need to specify both a Team ID and a Squad ID.
    /// </summary>
    public class SquadId
    {
        /// <summary>
        /// Gets the <see cref="int"/> value of the current <see cref="SquadId"/>
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Gets the sign, if the current squad id is no-squad
        /// </summary>
        public bool IsNoSquad { get { return this.Value == 0; } }

        /// <summary>
        /// Creates a new <see cref="SquadId"/> instance
        /// </summary>
        /// <param name="squadId"></param>
        public SquadId(string squadId)
        {
            #region Contracts

            if (squadId == null)
            {
                throw new ArgumentNullException("squadId");
            }

            var intValue = 0;
            if (!Int32.TryParse(squadId, out intValue))
            {
                throw new ArgumentOutOfRangeException("squadId");
            }

            if (intValue < 0 || intValue > 32)
            {
                throw new ArgumentOutOfRangeException("squadId");
            }

            #endregion

            this.Value = intValue;
        }
    }
}
