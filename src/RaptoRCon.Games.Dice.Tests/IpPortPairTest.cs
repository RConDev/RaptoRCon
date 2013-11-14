using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    public class IpPortPairTest
    {
        #region Ctor

        [Fact]
        public void Ctor_IpAddressNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new IpPortPair(null, 10000));
        }

        [Fact]
        public void Ctor_IpAddressNull_ThrowsArgumentNullExceptionParamNameIpAddress()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new IpPortPair(null, 10000));
            Assert.Equal("ipAddress", exception.ParamName);
        }

        [Fact]
        public void Ctor_Port0_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new IpPortPair(IPAddress.Parse("127.0.0.1"), 0));
        }

        [Fact]
        public void Ctor_Port0_ThrowsArgumentOutOfRangeExceptionParamNamePort()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new IpPortPair(IPAddress.Parse("127.0.0.1"), 0));
            Assert.Equal("port", exception.ParamName);
        }

        #endregion

        #region ToWords()

        [Fact]
        public void ToWords_Ip127001Port1024_WordsCount2()
        {
            var ipPort = new IpPortPair(IPAddress.Parse("127.0.0.1"), 1024);
            Assert.Equal(1, ipPort.ToWords().Count());
        }

        [Fact]
        public void ToWords_Ip127001Port1024_WordsDiceWord127001Port1024()
        {
            var expectedSequence = new[] { new DiceWord("127.0.0.1:1024") };
            var ipPort = new IpPortPair(IPAddress.Parse("127.0.0.1"), 1024);
            Assert.Equal(expectedSequence, ipPort.ToWords());
        }

        #endregion
    }
}
