using System;
using System.Collections.Generic;
using System.Linq;
using Seterlund.CodeGuard;

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
            Guard.That(() => teamId).IsNotNull();
            Guard.That(() => squadId).IsNotNull();

            TeamId = teamId;
            SquadId = squadId;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords()
                .Concat(TeamId.ToWords())
                .Concat(SquadId.ToWords());
        }
    }
}
