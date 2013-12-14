using System;
using System.Linq;
using RaptoRCon.Games.Dice.Commands;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests.Commands
{
    public class LoginHashedCommandTest
    {
        [Fact]
        public void Ctor_Nothing_ImplementsIDiceCommand()
        {
            var instance = new LoginHashedCommand();
            Assert.IsAssignableFrom<IDiceCommand>(instance);
        }

        [Fact]
        public void Ctor_Nothing_CommandNameLoginHashed()
        {
            var instance = new LoginHashedCommand();
            Assert.Equal("login.hashed", instance.CommandName);
        }

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginHashedCommand(null));
        }

        [Fact]
        public void Ctor_Null_ThrowsArgumentNullExceptionParamNameHashedPassword()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new LoginHashedCommand(null));
            Assert.Equal("passwordHash", exception.ParamName);
        }


        [Fact]
        public void Ctor_HexStringABC123_PasswordHashHexStringABC123()
        {
            var passwordHash = new HexString("ABC123");
            var command = new LoginHashedCommand(passwordHash);
            Assert.Equal(passwordHash, command.PasswordHash);
        }

        [Fact]
        public void ToWords_Nothing_WordsCount1()
        {
            var instance = new LoginHashedCommand();
            Assert.Equal(1, instance.ToWords().Count());
        }

        [Fact]
        public void ToWords_Nothing_WordsDiceWordLoginHashed()
        {
            var expectedSequence = new[] {new DiceWord("login.hashed")};
            var instance = new LoginHashedCommand();
            Assert.Equal(expectedSequence, instance.ToWords());
        }

        [Fact]
        public void ToWords_HexStringABC123_WordsDiceWordLoginHashedDiceWordABC123()
        {
            var expectedSequence = new[] { new DiceWord("login.hashed"), new DiceWord("ABC123"),  };
            var instance = new LoginHashedCommand(new HexString("ABC123"));
            Assert.Equal(expectedSequence, instance.ToWords());
        }
    }
}
