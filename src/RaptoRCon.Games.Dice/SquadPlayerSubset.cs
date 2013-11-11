using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Describes a subset of players within a special squad
    /// </summary>
    public class SquadPlayerSubset : PlayerSubset
    {
        /// <summary>
        /// Gets the Id of the Team the squad is located in
        /// </summary>
        public TeamId TeamId { get; private set; }

        /// <summary>
        /// Gets the Id of the Squad
        /// </summary>
        public SquadId SquadId { get; private set; }

        /// <summary>
        /// Creates a new <see cref="SquadPlayerSubset"/> instance
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="squadId"></param>
        public SquadPlayerSubset(TeamId teamId, SquadId squadId)
            : base(PlayerSubsetType.Squad)
        {
            #region Contracts

            if (teamId == null)
            {
                throw new ArgumentNullException("teamId");
            }

            if (squadId == null)
            {
                throw new ArgumentNullException("squadId");
            }

            #endregion

            this.TeamId = teamId;
            this.SquadId = squadId;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords()
                .Concat(this.TeamId.ToWords())
                .Concat(this.SquadId.ToWords());
        }
    }
}
