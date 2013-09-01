using System;
using RaptoRCon.Dice.Factories;
using Xunit;

namespace RaptoRCon.Dice.Tests.Factories
{
    public class WordFactoryTest
    {
        private DiceWordFactory diceWordFactory;

        public WordFactoryTest()
        {
            this.diceWordFactory = new DiceWordFactory();
        }

        #region FromBytes()

        [Fact]
        public void FromBytes_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => diceWordFactory.FromBytes(null));
        }

        [Fact]
        public void FromBytes_WordTestBytes_ReturnsWordTest()
        {
            // new DiceWord("Test");
            var bytes = Convert.FromBase64String("BAAAAFRlc3QA");
            
            var result = diceWordFactory.FromBytes(bytes);
            
            Assert.Equal("Test", result.Content);
            Assert.Equal(4u, result.Size);
        }

        #endregion
    }
}
