using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class TeamIdTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new TeamId(null));
        }

        [Fact]
        public void Ctor_0_ValueInt0()
        {
            var teamId = new TeamId("0");
            Assert.Equal(0, teamId.Value);
        }

        [Fact]
        public void Ctor_Minus1_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TeamId("-1"));
        }

        [Fact]
        public void Ctor_test_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TeamId("test"));
        }

        [Fact]
        public void Ctor_16_ValueInt16()
        {
            var teamId = new TeamId("16");
            Assert.Equal(16, teamId.Value);
        }

        [Fact]
        public void Ctor_17_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TeamId("17"));
        }

        #endregion

        #region IsNeutral

        [Fact]
        public void IsNeutral_Id0_True()
        {
            var teamId = new TeamId("0");
            Assert.True(teamId.IsNeutral);
        }

        [Fact]
        public void IsNeutral_Id1_True()
        {
            var teamId = new TeamId("1");
            Assert.False(teamId.IsNeutral);
        }

        #endregion
    }
}
