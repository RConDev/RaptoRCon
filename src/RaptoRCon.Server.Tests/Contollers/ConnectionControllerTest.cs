using AssertExLib;
using Moq;
using RaptoRCon.Server.Controllers;
using RaptoRCon.Server.Hosting;
using RaptoRCon.Server.Hosting.Exceptions;
using RaptoRCon.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Server.Tests.Contollers
{
    [ExcludeFromCodeCoverage]
    public class ConnectionControllerTest
    {
        #region Delete(Connection)

        //[Fact]
        //public async void Delete_ConnectionIdUnknown_ThrowsInvalidOperationException()
        //{
        //    var connectionHostMock = new Mock<IConnectionHost>();
        //    var sut = new ConnectionController(connectionHostMock.Object);
        //    AssertEx.TaskThrows<UnknownConnectionIdException>(() => sut.Delete(new Connection() {Id = Guid.NewGuid(), HostName = "testhostname", Port= 12345}));
        //}

        #endregion
    }
}
