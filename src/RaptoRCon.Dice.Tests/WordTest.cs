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
    }
}
