using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class IpPlayerIdTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new IpPlayerId(null));
        }

        [Fact]
        public void Ctor_null_ThrowsArgumentNullExceptionParamNameIp()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new IpPlayerId(null));
            Assert.Equal("ip", exception.ParamName);
        }

        [Fact]
        public void Ctor_IpAddress_IpIpAddress()
        {
            var ipId = new IpPlayerId("127.0.0.1");
            Assert.Equal("127.0.0.1", ipId.Ip);
        }

        [Fact]
        public void Ctor_IpAddress_TypeIdTypeIp()
        {
            var ipId = new IpPlayerId("127.0.0.1");
            Assert.Equal(IdType.Ip, ipId.Type);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_IpAddress_WordsCount2()
        {
            var ipId = new IpPlayerId("127.0.0.1");
            Assert.Equal(2, ipId.ToWords().Count());
        }

        [Fact]
        public void ToWords_IpAddressIp127001_WordsIp127001()
        {
            var expectedSequence = new[] { new DiceWord("ip"), new DiceWord("127.0.0.1") };
            var ipId = new IpPlayerId("127.0.0.1");
            Assert.Equal(expectedSequence, ipId.ToWords());
        }

        #endregion
    }
}
