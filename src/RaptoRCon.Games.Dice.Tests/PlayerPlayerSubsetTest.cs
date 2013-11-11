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
    public class PlayerPlayerSubsetTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException() 
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new PlayerPlayerSubset(null));
            Assert.Equal("playerName", exception.ParamName);
        }

        [Fact]
        public void Ctor_PlayerNameSoldier_PlayerNameSoldier() 
        {
            var playerName = new PlayerName("Soldier");
            var subset = new PlayerPlayerSubset(playerName);
            Assert.Equal(playerName, subset.PlayerName);
        }

        [Fact]
        public void Ctor_PlayerNameSoldier_TypePlayerSubsetTypePlayer()
        {
            var playerName = new PlayerName("Soldier");
            var subset = new PlayerPlayerSubset(playerName);
            Assert.Equal(PlayerSubsetType.Player, subset.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_PlayerNameSoldier_WordsCount2()
        {
            var subset = new PlayerPlayerSubset(new PlayerName("Soldier"));
            Assert.Equal(2, subset.ToWords().Count());
        }

        [Fact]
        public void ToWords_PlayerNameSoldier_DiceWordPlayerDiceWordSoldier()
        {
            var expectedSequence = new[] { new DiceWord("player"), new DiceWord("Soldier") };
            var subset = new PlayerPlayerSubset(new PlayerName("Soldier"));
            Assert.Equal(expectedSequence, subset.ToWords());
        }

        #endregion
    }
}
