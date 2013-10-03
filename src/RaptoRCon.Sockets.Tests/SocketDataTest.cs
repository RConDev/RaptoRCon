using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace RaptoRCon.Sockets.Tests
{
    /// <summary>
    /// Tests for <see cref="SocketData"/>
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SocketDataTest
    {
        #region ctor

        [Fact]
        public void ctor_WithData_IsInstanceOfISocketData()
        {
            var bytes = Encoding.Default.GetBytes("Mein Test");
            var socketData = new SocketData(bytes);
            Assert.IsAssignableFrom<ISocketData>(socketData);
        }

        [Fact]
        public void ctor_WithNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocketData(null));
        }

        [Fact]
        public void ctor_WithEmptyData_ReturnsData()
        {
            var socketData = new SocketData(new byte[0]);
            Assert.NotNull(socketData);
            Assert.Equal(new byte[0], socketData.Data);
        }

        [Fact]
        public void ctor_WithData_ReturnsData()
        {
            var bytes = Encoding.Default.GetBytes("Mein Test");
            var socketData = new SocketData(bytes);
            Assert.NotNull(socketData);
            Assert.Equal(bytes, socketData.Data);
        }

        #endregion
    }
}
