using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class TeamPlayerSubsetTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new TeamPlayerSubset(null));
        }

        [Fact]
        public void Ctor_TeamId1_TeamId1()
        {
            var teamId = new TeamId("1");
            var subset = new TeamPlayerSubset(teamId);
            Assert.Equal(teamId, subset.TeamId);
        }

        [Fact]
        public void Ctor_TeamId1_TypePlayerSubsetTypeTeam()
        {
            var teamId = new TeamId("1");
            var subset = new TeamPlayerSubset(teamId);
            Assert.Equal(PlayerSubsetType.Team, subset.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_TeamId1_WordsCount2() 
        {
            var teamId = new TeamId("1");
            var teamPlayerSubset = new TeamPlayerSubset(teamId);

            Assert.Equal(2, teamPlayerSubset.ToWords().Count());
        }

        [Fact]
        public void ToWords_TeamId1_FirstWordTeam()
        {
            var teamId = new TeamId("1");
            var teamPlayerSubset = new TeamPlayerSubset(teamId);

            Assert.Equal(new DiceWord("team"), teamPlayerSubset.ToWords().First());
        }

        [Fact]
        public void ToWords_TeamId1_SecoundWord1()
        {
            var teamId = new TeamId("1");
            var teamPlayerSubset = new TeamPlayerSubset(teamId);

            Assert.Equal(new DiceWord("1"), teamPlayerSubset.ToWords().Last());
        }

        #endregion
    }
}
