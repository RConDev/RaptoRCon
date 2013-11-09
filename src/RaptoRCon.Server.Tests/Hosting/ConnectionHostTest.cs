using Moq;
using RaptoRCon.Games.Dice;
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
        private ConnectionHost sut;
        private Mock<IHostedConnection> hostedConnectionMock;
        
        public ConnectionHostTest()
        {
            sut = new ConnectionHost();
            hostedConnectionMock = new Mock<IHostedConnection>();
        }

        #region Get()

        [Fact]
        public void Get_WithNoConnectionAdded_ReturnsEmptyEnumerable()
        {
            IEnumerable<IHostedConnection> connections = sut.Get();
            Assert.False(connections.Any());
        }

        [Fact]
        public void Get_AfterConnectionAdded_Returns1ItemInEnumerable() 
        {
            sut.Add(hostedConnectionMock.Object);
            
            var connections = sut.Get();

            Assert.True(connections.Count() == 1);
        }

        #endregion

        #region Get(id)

        [Fact]
        public void Get_WithNoConnectionAdded_ThrowsUnknownConnectionIdException()
        {
            Assert.Throws<UnknownConnectionIdException>(() => sut.Get(System.Guid.NewGuid()));
        }
        
        #endregion

        #region Add(IHostedConnection)

        [Fact]
        public void Add_WithHostedConnection_ReturnsConnectionsGuid() 
        { 
            var guid = System.Guid.NewGuid();
            hostedConnectionMock.Setup(x => x.Id).Returns(guid);
            var hostedConnection = hostedConnectionMock.Object;
            sut.Add(hostedConnection);
            
            var connection = sut.Get(guid);
            Assert.Equal(hostedConnection, connection);
        }

        [Fact]
        public void Add_SameConnectionAddedTwice_ThrowsConnectionAlreadyAddedException()
        {
            var guid = System.Guid.NewGuid();
            hostedConnectionMock.Setup(x => x.Id).Returns(guid);
            var hostedConnection = hostedConnectionMock.Object;

            sut.Add(hostedConnection);
            Assert.Throws<ConnectionAlreadyAddedException>(() => sut.Add(hostedConnection));
        }

        #endregion

        #region Remove(IHostedConnection)

        [Fact]
        public void Remove_IHostedConnectionWithEmptyConnectionHost_ReturnsFalse()
        {
            Assert.False(sut.Remove(hostedConnectionMock.Object));
        }

        [Fact]
        public void Remove_AddedIHostedConnection_ReturnsTrue()
        {
            var hostedConnection = hostedConnectionMock.Object;
            sut.Add(hostedConnection);

            Assert.True(sut.Remove(hostedConnection));
        }

        [Fact]
        public void Remove_AddedIHostedConnection_RemovesConnectionFromList()
        {
            var hostedConnection = hostedConnectionMock.Object;
            sut.Add(hostedConnection);
            sut.Remove(hostedConnection);
            Assert.Equal(0, sut.Get().Count());
        }

        #endregion
    }
}
