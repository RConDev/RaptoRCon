using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Tests
{
    public class GameDataEventArgsTest
    {
        [Fact]
        public void CreateInstance_IGameDataInstance_GameDataIGameDataInstance() 
        {
            var gameDataMock = new Mock<IGameData>().Object;
            var gameDataEventArgs = new GameDataEventArgs(gameDataMock);
            Assert.Equal(gameDataMock, gameDataEventArgs.GameData);
        }
    }
}
