using Moq;
using RaptoRCon.Dice;
using RaptoRCon.Server.Hosting;
using RaptoRCon.Server.Hosting.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Server.Tests.Hosting
{
    [ExcludeFromCodeCoverage]
    public class ConnectionHostTest
    {
        private ConnectionHost connectionHost;
        private Mock<IHostedConnection> hostedConnectionMock;
        
        public ConnectionHostTest()
        {
            connectionHost = new ConnectionHost();
            hostedConnectionMock = new Mock<IHostedConnection>();
        }

        #region Get()

        [Fact]
        public void Get_WithNoConnectionAdded_ReturnsEmptyEnumerable()
        {
            IEnumerable<IHostedConnection> connections = connectionHost.Get();
            Assert.False(connections.Any());
        }

        [Fact]
        public void Get_AfterConnectionAdded_Returns1ItemInEnumerable() 
        {
            connectionHost.Add(hostedConnectionMock.Object);
            
            var connections = connectionHost.Get();

            Assert.True(connections.Count() == 1);
        }

        #endregion

        #region Get(id)

        [Fact]
        public void Get_WithNoConnectionAdded_ThrowsUnknownConnectionIdException()
        {
            Assert.Throws<UnknownConnectionIdException>(() => connectionHost.Get(Guid.NewGuid()));
        }
        
        #endregion

        #region Add(IHostedConnection)

        [Fact]
        public void Add_WithHostedConnection_ReturnsConnectionsGuid() 
        { 
            var guid = Guid.NewGuid();
            hostedConnectionMock.Setup(x => x.Id).Returns(guid);
            var hostedConnection = hostedConnectionMock.Object;
            connectionHost.Add(hostedConnection);
            
            var connection = connectionHost.Get(guid);
            Assert.Equal(hostedConnection, connection);
        }

        [Fact]
        public void Add_SameConnectionAddedTwice_ThrowsConnectionAlreadyAddedException()
        {
            var guid = Guid.NewGuid();
            hostedConnectionMock.Setup(x => x.Id).Returns(guid);
            var hostedConnection = hostedConnectionMock.Object;

            connectionHost.Add(hostedConnection);
            Assert.Throws<ConnectionAlreadyAddedException>(() => connectionHost.Add(hostedConnection));
        }

        #endregion
    }
}
