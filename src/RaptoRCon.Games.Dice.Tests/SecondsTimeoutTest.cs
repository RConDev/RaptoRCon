using System;
using System.Linq;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class SecondsTimeoutTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new SecondsTimeout(null));
            Assert.Equal("seconds", exception.ParamName);
        }

        [Fact]
        public void Ctor_Seconds2_Seconds2()
        {
            var timeout = new SecondsTimeout("2");
            Assert.Equal(2u, timeout.Seconds);
        }

        [Fact]
        public void Ctor_Seconds2_TypeTimeoutTypeSeconds()
        {
            var timeout = new SecondsTimeout("2");
            Assert.Equal(TimeoutType.Seconds, timeout.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_Seconds2_WordsCount2()
        {
            var timeout = new SecondsTimeout("2");
            Assert.Equal(2, timeout.ToWords().Count());
        }

        [Fact]
        public void ToWords_Seconds2_WordsDiceWordSecondsDiceWord2()
        {
            var expectedSequence = new[] { new DiceWord("seconds"), new DiceWord("2") };
            var timeout = new SecondsTimeout("2");
            Assert.Equal(expectedSequence, timeout.ToWords());
        }

        #endregion
    }
}
