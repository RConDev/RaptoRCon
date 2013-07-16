using System;
using System.Linq;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class WordTest
    {
        #region ctor

        [Fact]
        public void ctor_ImplementsIWord()
        {
            var word = new Word("1");
            Assert.IsAssignableFrom<IWord>(word);
        }

        [Fact]
        public void ctor_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Word(null));
        }

        [Fact]
        public void ctor_MyCommand_ContentMyCommand()
        {
            var content = "MyCommand";
            var word = new Word(content);
            Assert.Equal(content, word.Content);
        }

        [Fact]
        public void ctor_MyCommand_Size9()
        {
            var content = "MyCommand";
            var word = new Word(content);
            Assert.Equal((uint)content.Length, word.Size);
        }

        #endregion

        #region Terminator

        [Fact]
        public void Terminator_NULLByte()
        {
            var word = new Word("1");
            Assert.Equal('\0', word.Terminator);
        }

        #endregion

        #region ToBytes()

        [Fact]
        public void ToBytes_WordTest_BytesLength9()
        {
            var word = new Word("Test");
            var bytes = word.ToBytes();
            Assert.Equal(9, bytes.Count());
        }

        [Fact]
        public void ToBytes_WordTest_BytesEquals()
        {
            var word = new Word("Test");
            var bytes = word.ToBytes();
            byte[] expectedBytes = Convert.FromBase64String("BAAAAFRlc3QA");
            Assert.Equal(expectedBytes, bytes);
        }

        #endregion

        #region Equals() 

        [Fact]
        public void Equals_WordTest_True()
        {
            var word = new Word("Test");
            var word2 = new Word("Test");

            Assert.Equal(word, word2);
        }

        [Fact]
        public void Equals_WordTestWordTest2_False()
        {
            var word = new Word("Test");
            var word2 = new Word("Test2");

            Assert.NotEqual(word, word2);
        }

        [Fact]
        public void Equals_WordTestStringTest_False()
        {
            var word = new Word("Test");

            Assert.False(Equals(word, "Test"));
        }

        #endregion

        #region GetHashCode()

        [Fact]
        public void GetHashCode_SameInstance_Equal()
        {
            var instance = new Word("Test");
            Assert.Equal(instance.GetHashCode(), instance.GetHashCode());
        }

        #endregion
    }
}
