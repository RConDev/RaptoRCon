using System;
using System.Linq;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class NamePlayerIdTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new NamePlayerId(null));
        }

        [Fact]
        public void Ctor_null_ThrowsArgumentNullExceptionParamNamePlayerName()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new NamePlayerId(null));
            Assert.Equal("playerName", exception.ParamName);
        }

        [Fact]
        public void Ctor_PlayerNamePlayer_NamePlayerNamePlayer()
        {
            var playerName = new PlayerName("Player");
            var name = new NamePlayerId(playerName);
            Assert.Equal(playerName, name.Name);
        }

        [Fact]
        public void Ctor_PlayerNamePlayer_TypeIdTypeName()
        {
            var playerName = new PlayerName("Player");
            var name = new NamePlayerId(playerName);
            Assert.Equal(IdType.Name, name.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_PlayerNamePlayer_WordsCount2()
        {
            var nameId = new NamePlayerId(new PlayerName("Player"));
            Assert.Equal(2, nameId.ToWords().Count());
        }

        [Fact]
        public void ToWords_PlayerNamePlayer_WordsNamePlayer()
        {
            var expectedSequence = new[] { new DiceWord("name"), new DiceWord("Player") };
            var nameId = new NamePlayerId(new PlayerName("Player"));
            Assert.Equal(expectedSequence, nameId.ToWords());
        }

        #endregion
    }
}
