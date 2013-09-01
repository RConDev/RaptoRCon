using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RaptoRCon.Sockets;
using Xunit;

namespace RaptoRCon.Dice.Tests
{
    public class DiceConnectionTest
    {
        #region CTOR

        [Fact]
        public void Ctor_InstanceImplementsIDiceConnection()
        {
            var socketMock = new Mock<ISocket>();
                var instance = new DiceConnection(socketMock.Object, (sender, args) => {});
            Assert.IsAssignableFrom<IDiceConnection>(instance);
        }

        [Fact]
        public void Ctor_SocketNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new DiceConnection(null, (sender, args) => { }));
        }

        #endregion

        #region SendAsync()



        #endregion
    }
}
