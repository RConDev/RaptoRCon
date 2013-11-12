using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class PermanentTimeoutTest
    {
        #region Ctor

        [Fact]
        public void Ctor_Nothing_ImplementsITimeout()
        {
            var timeout = new PermanentTimeout();
            Assert.IsAssignableFrom<ITimeout>(timeout);
        }

        [Fact]
        public void Ctor_Nothing_TypeTimeoutTypePerm()
        {
            var timeout = new PermanentTimeout();
            Assert.Equal(TimeoutType.Perm, timeout.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_WordsCount1()
        {
            var timeout = new PermanentTimeout();
            Assert.Equal(1, timeout.ToWords().Count());
        }

        [Fact]
        public void ToWords_WordsPerm()
        {
            var expectedSequence = new[] { new DiceWord("perm") };
            var timeout = new PermanentTimeout();
            Assert.Equal(expectedSequence, timeout.ToWords());
        }

        #endregion
    }
}
