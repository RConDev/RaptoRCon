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
    public class PasswordTest
    {
        #region Ctor

        [Fact]
        public void Ctor_myPassword_ValuemyPassword() 
        {
            var password = new Password("myPassword");
            Assert.Equal("myPassword", password.Value);
        }

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException() 
        {
            Assert.Throws<ArgumentNullException>(() => new Password(null));
        }

        [Fact]
        public void Ctor_stringMyPasswordIsTooLo_ThrowsArgumentOutOfRangeException() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Password("MyPasswordIsTooLo"));
        }

        [Fact]
        public void Ctor_WithSpecialChar_ThrowsArgumentOutOfRangeException() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Password("MyPassword$"));
        }

        #endregion
    }
}
