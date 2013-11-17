using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace RaptoRCon.Sockets.Tests
{
    public class SocketClientTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocketClient(null));
        }

        #endregion

        #region DisconnectAsync()

        #endregion
    }
}
