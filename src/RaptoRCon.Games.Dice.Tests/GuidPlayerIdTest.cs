using System;
using System.Linq;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class GuidPlayerIdTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new GuidPlayerId(null));
        }

        [Fact]
        public void Ctor_null_ThrowsArgumentNullExceptionParamName()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new GuidPlayerId(null));
            Assert.Equal("guid", exception.ParamName);
        }

        [Fact]
        public void Ctor_DiceGuidSample_GuidDiceGuidSample()
        {
            var diceGuid = new DiceGuid("EA_ABCDEF1234567890ABCDEF1234567890");
            var guidId = new GuidPlayerId(diceGuid);
            Assert.Equal(diceGuid, guidId.Guid);
        }

        [Fact]
        public void Ctor_DiceGuidSample_TypeIdTypeGuid()
        {
            var diceGuid = new DiceGuid("EA_ABCDEF1234567890ABCDEF1234567890");
            var guidId = new GuidPlayerId(diceGuid);
            Assert.Equal(IdType.Guid, guidId.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_DiceGuidSample_WordsCount2()
        {
            var diceGuid = new DiceGuid("EA_ABCDEF1234567890ABCDEF1234567890");
            var guidId = new GuidPlayerId(diceGuid);
            Assert.Equal(2, guidId.ToWords().Count());
        }

        #endregion
    }
}
