using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    /// <summary>
    /// Tests for the basic type <see cref="HexString"/>
    /// </summary>
    public class HexStringTest
    {
        #region Ctor

        [Fact]
        public void Ctor_ABC123_HexStringABC123()
        {
            var hexString = new HexString("ABC123");
            Assert.Equal("ABC123", hexString.Value);
        }

        [Fact]
        public void Ctor_AG12_ThrowsArgumentOutOfRangeException() 
        { 
            Assert.Throws<ArgumentOutOfRangeException>(() => new HexString("AG12"));
        }

        [Fact]
        public void Ctor_abc123_HexStringABC123() 
        {
            var hexString = new HexString("abc123");
            Assert.Equal("ABC123", hexString.Value);
        }

        [Fact]
        public void Ctor_abc_ThrowsArgumentOutOfRangeException() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new HexString("abc"));
        }

        #endregion
    }
}
