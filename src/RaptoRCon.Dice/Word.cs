using System;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// Implementation of <see cref="IWord"/>
    /// </summary>
    public class Word : IWord
    {
        /// <summary>
        /// Creates a new <see cref="Word"/> instance
        /// </summary>
        /// <param name="content"></param>
        public Word(string content)
        {
            Content = content;
        }

        /// <summary>
        /// Gets the number of bytes in the <see cref="IWord"/> instance
        /// </summary>
        /// <remarks>
        /// The trailing NULL-Byte is excluded.
        /// </remarks>
        public uint Size
        {
            get
            {
                return Convert.ToUInt32(Content.Length);
            }
        }

        /// <summary>
        /// Gets the content of the <see cref="IWord"/> instance
        /// </summary>
        /// <remarks>
        /// The <see cref="IWord.Content"/> must not contain any NULL-Byte
        /// </remarks>
        public string Content { get; private set; }

        /// <summary>
        /// Gets the Terminator 
        /// </summary>
        /// <remarks>
        /// In the DICE specs this is a NULL-Byte
        /// </remarks>
        public char Terminator { get; private set; }
    }
}