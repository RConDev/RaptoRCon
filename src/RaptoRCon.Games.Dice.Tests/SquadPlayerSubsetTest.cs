using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    [ExcludeFromCodeCoverage]
    public class SquadPlayerSubsetTest
    {
        #region Ctor

        [Fact]
        public void Ctor_TeamIdNull_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new SquadPlayerSubset(null, new SquadId("0")));
            Assert.Equal("teamId", exception.ParamName);
        }

        [Fact]
        public void Ctor_SquadIdNull_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new SquadPlayerSubset(new TeamId("1"), null));
            Assert.Equal("squadId", exception.ParamName);
        }

        [Fact]
        public void Ctor_TeamId1_TeamId1()
        {
            var teamId = new TeamId("1");
            var subset = new SquadPlayerSubset(teamId, new SquadId("0"));

            Assert.Equal(teamId, subset.TeamId);
        }

        [Fact]
        public void Ctor_SquadId1_SquadId1()
        {
            var squadId = new SquadId("1");
            var subset = new SquadPlayerSubset(new TeamId("1"), squadId);

            Assert.Equal(squadId, subset.SquadId);
        }

        [Fact]
        public void Ctor_TeamId1SquadId1_TypePlayerSubsetTypeSquad()
        {
            var subset = new SquadPlayerSubset(new TeamId("1"), new SquadId("1"));

            Assert.Equal(PlayerSubsetType.Squad, subset.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_TeamId1SquadId1_WordsCount3()
        {
            var subset = new SquadPlayerSubset(new TeamId("1"), new SquadId("1"));
            Assert.Equal(3, subset.ToWords().Count());
        }

        [Fact]
        public void ToWords_TeamId1SquadId1_DiceWordSquadDiceWord1DiceWord1()
        {
            var expectedSequence =
                new[] { new DiceWord("squad"), new DiceWord("1"), new DiceWord("1") };
            
            var subset = new SquadPlayerSubset(new TeamId("1"), new SquadId("1"));
            Assert.Equal(expectedSequence, subset.ToWords());
        }

        #endregion
    }
}
