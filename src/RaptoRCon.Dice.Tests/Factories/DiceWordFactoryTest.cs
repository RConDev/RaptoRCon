using System;
using RaptoRCon.Dice.Factories;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RaptoRCon.Dice.Tests.Factories
{
    [ExcludeFromCodeCoverage]
    public class DiceWordFactoryTest
    {
        private DiceWordFactory diceWordFactory;

        public DiceWordFactoryTest()
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

        #region FromString()

        [Fact]
        public void FromString_Version_ReturnsIDiceWordEnumerable()
        {
            var versionString = "version";
            IEnumerable<IDiceWord> words = diceWordFactory.FromString(versionString);
            Assert.IsAssignableFrom(typeof(IEnumerable<IDiceWord>), words);
        }

        #endregion
    }
}
