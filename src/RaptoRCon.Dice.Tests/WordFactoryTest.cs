using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class WordFactoryTest
    {
        private WordFactory wordFactory;

        public WordFactoryTest()
        {
            this.wordFactory = new WordFactory();
        }

        #region FromBytes()

        [Fact]
        public void FromBytes_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => wordFactory.FromBytes(null));
        }

        [Fact]
        public void FromBytes_WordTestBytes_ReturnsWordTest()
        {
            // new Word("Test");
            var bytes = Convert.FromBase64String("BAAAAFRlc3QA");
            
            var result = wordFactory.FromBytes(bytes);
            
            Assert.Equal("Test", result.Content);
            Assert.Equal(4u, result.Size);
        }

        #endregion
    }
}
