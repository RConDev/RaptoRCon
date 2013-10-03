using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace RaptoRCon.Sockets.Tests
{
    [ExcludeFromCodeCoverage]
    public class SocketDataReceivedEventArgsTest
    {
        #region ctor

        [Fact]
        public void ctor_WithData_IsInstanceOfEventArgs()
        {
            var bytes = Encoding.Default.GetBytes("Mein Test");
            var eventArgs = new SocketDataReceivedEventArgs(bytes);
            Assert.IsAssignableFrom<EventArgs>(eventArgs);
        }

        [Fact]
        public void ctor_WithNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocketDataReceivedEventArgs(null));
        }

        [Fact]
        public void ctor_WithEmptyData_ReturnsData()
        {
            var eventArgs = new SocketDataReceivedEventArgs(new byte[0]);
            Assert.NotNull(eventArgs);
            Assert.Equal(new byte[0], eventArgs.DataReceived);
        }

        [Fact]
        public void ctor_WithData_ReturnsData()
        {
            var bytes = Encoding.Default.GetBytes("Mein Test");
            var socketData = new SocketDataReceivedEventArgs(bytes);
            Assert.NotNull(socketData);
            Assert.Equal(bytes, socketData.DataReceived);
        }

        #endregion
    }
}
