using System.Collections.Generic;
using System.Linq;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice
{
    public class TeamPlayerSubset : PlayerSubset
    {
        public TeamId TeamId { get; private set; }

        public TeamPlayerSubset(TeamId teamId) : base(PlayerSubsetType.Team)
        {
            Guard.That(() => teamId).IsNotNull();

            TeamId = teamId;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords()
                .Concat(this.TeamId.ToWords());
        }
    }
}
