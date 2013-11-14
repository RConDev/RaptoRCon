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
    public class DiceGuidTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceGuid(null));
        }

        [Fact]
        public void Ctor_MyWrongGuid_ThrowsArgumentOutOfRangeException() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DiceGuid("MyWrongGuid"));
        }

        [Fact]
        public void Ctor_EB_5E58A522B9BF4E7DADB5212623C3B721_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DiceGuid("EB_5E58A522B9BF4E7DADB5212623C3B721"));
        }

        [Fact]
        public void Ctor_EA_5E58A522B9BF4E7DADB5212623C3B721_ValueEA_5E58A522B9BF4E7DADB5212623C3B721()
        {
            var guid = new DiceGuid("EA_5E58A522B9BF4E7DADB5212623C3B721");
            Assert.Equal("EA_5E58A522B9BF4E7DADB5212623C3B721", guid.Value);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_EA_5E58A522B9BF4E7DADB5212623C3B721_WordsCount1()
        {
            var guid = new DiceGuid("EA_5E58A522B9BF4E7DADB5212623C3B721");
            Assert.Equal(1, guid.ToWords().Count());
        }

        [Fact]
        public void ToWords_EA_5E58A522B9BF4E7DADB5212623C3B721_WordsDiceWordEA_5E58A522B9BF4E7DADB5212623C3B721()
        {
            var expectedSequence = new[] {new DiceWord("EA_5E58A522B9BF4E7DADB5212623C3B721")};
            var guid = new DiceGuid("EA_5E58A522B9BF4E7DADB5212623C3B721");
            Assert.Equal(expectedSequence, guid.ToWords());
        }

        #endregion
    }
}
