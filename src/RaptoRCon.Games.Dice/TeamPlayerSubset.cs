using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Games.Dice
{
    public class TeamPlayerSubset : PlayerSubset
    {
        public TeamId TeamId { get; private set; }

        public TeamPlayerSubset(TeamId teamId) : base(PlayerSubsetType.Team)
        {
            #region Contracts

            if (teamId == null)
            {
                throw new ArgumentNullException("teamId");
            }

            #endregion

            this.TeamId = teamId;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords()
                .Concat(this.TeamId.ToWords());
        }
    }
}
