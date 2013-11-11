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
    public class SquadIdTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SquadId(null));
        }

        [Fact]
        public void Ctor_0_ValueInt0()
        {
            var squadId = new SquadId("0");
            Assert.Equal(0, squadId.Value);
        }

        [Fact]
        public void Ctor_Minus1_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquadId("-1"));
        }

        [Fact]
        public void Ctor_test_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquadId("test"));
        }

        [Fact]
        public void Ctor_32_ValueInt32()
        {
            var squadId = new SquadId("32");
            Assert.Equal(32, squadId.Value);
        }

        [Fact]
        public void Ctor_33_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquadId("33"));
        }

        #endregion

        #region IsNoSquad

        [Fact]
        public void IsNoSquad_Id0_True()
        {
            var teamId = new SquadId("0");
            Assert.True(teamId.IsNoSquad);
        }

        [Fact]
        public void IsNoSquad_Id1_True()
        {
            var teamId = new SquadId("1");
            Assert.False(teamId.IsNoSquad);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_SquadId1_WordsCount1()
        {
            var squadId = new SquadId("1");
            Assert.Equal(1, squadId.ToWords().Count());
        }

        [Fact]
        public void ToWords_SquadId1_DiceWord1()
        {
            var squadId = new SquadId("1");
            Assert.Equal(new DiceWord("1"), squadId.ToWords().First());
        }

        #endregion
    }
}
