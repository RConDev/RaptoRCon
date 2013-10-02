using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command
{
    using RaptoRCon.Dice;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class DiceCommandStringTest
    {
        [Fact]
        public void GetParts_WithSimpleWords_ReturnsValue()
        {
            const string aString = "admin.kickPlayer soldier1 the-reason";
            var commandString = new DiceCommandString(aString);
            var parts = commandString.ToWords();
            var expectedParts = new IDiceWord[] {new DiceWord("admin.kickPlayer"), new DiceWord("soldier1"), new DiceWord("the-reason")};
            Assert.True(expectedParts.SequenceEqual(parts));
        }

        [Fact]
        public void GetParts_WithQuotesAndSpace_ReturnsValue()
        {
            const string aString = "admin.kickPlayer soldier1 \"the reason\"";
            var expectedParts = new IDiceWord[] { new DiceWord("admin.kickPlayer"), new DiceWord("soldier1"), new DiceWord("the reason") };
            var commandString = new DiceCommandString(aString);
            var parts = commandString.ToWords();
            Assert.True(expectedParts.SequenceEqual(parts));
        }

        [Fact]
        public void GetParts_WithQuotesAndMultipleSpace_ReturnsValue()
        {
            const string aString = "admin.kickPlayer soldier1 \"the unique reason\"";
            var expectedParts = new IDiceWord[] { new DiceWord("admin.kickPlayer"), new DiceWord("soldier1"), new DiceWord("the unique reason") };
            var commandString = new DiceCommandString(aString);
            var parts = commandString.ToWords();
            Assert.True(expectedParts.SequenceEqual(parts));
        }
    }
}
