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
    public class AllPlayerSubsetTest
    {
        #region Ctor

        [Fact]
        public void Ctor_Nothing_TypePlayerSubsetTypeAll()
        {
            var subset = new AllPlayerSubset();
            Assert.Equal(PlayerSubsetType.All, subset.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_Nothing_WordsCount1()
        {
            var subset = new AllPlayerSubset();
            Assert.Equal(1, subset.ToWords().Count());
        }

        [Fact]
        public void ToWords_Nothing_WordsAll()
        {
            var subset = new AllPlayerSubset();
            Assert.Equal(new DiceWord("all"), subset.ToWords().First());
        }

        #endregion
    }
}
