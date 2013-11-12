using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class RoundsTimeoutTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RoundsTimeout(null));
            Assert.Equal("rounds", exception.ParamName);
        }

        [Fact]
        public void Ctor_2_Rounds2()
        {
            var timeout = new RoundsTimeout("2");
            Assert.Equal(2u, timeout.Rounds);
        }

        [Fact]
        public void Ctor_2_TypeTimeoutTypeRounds()
        {
            var timeout = new RoundsTimeout("2");
            Assert.Equal(TimeoutType.Rounds, timeout.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_Rounds2_WordsCount2()
        {
            var timeout = new RoundsTimeout("2");
            Assert.Equal(2, timeout.ToWords().Count());
        }

        [Fact]
        public void ToWords_Rounds2_WordsDiceWordRoundsDiceWord2()
        {
            var expectedSequence = new[] { new DiceWord("rounds"), new DiceWord("2") };
            var timeout = new RoundsTimeout("2");
            Assert.Equal(expectedSequence, timeout.ToWords());
        }

        #endregion
    }
}
