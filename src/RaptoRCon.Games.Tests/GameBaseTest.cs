using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Tests
{
    public class GameBaseTest
    {
        #region TestImplementation

        private class TestGameBase : GameBase
        {
            internal TestGameBase() : base(TestGameGuid, TestGameName, TestGameHomepage) { }

            public override IGameConnectionFactory ConnectionFactory
            {
                get { return null; }
            }
        }

        #endregion

        private static readonly Guid TestGameGuid = new Guid("862989EE-0670-4A94-84FA-61BFDB071972"); 
        private static readonly string TestGameName =  "MyGame";
        private static readonly Uri TestGameHomepage = new Uri("http://www.testgame.com");

        private static TestGameBase CreateInstance()
        {
            return new TestGameBase();
        }

        [Fact]
        public void Ctor_Nothing_Guid862989EE_0670_4A94_84FA_61BFDB071972()
        {
            Assert.Equal(TestGameGuid, CreateInstance().Id);
        }

        [Fact]
        public void Ctor_Nothing_NameMyGame()
        {
            Assert.Equal(TestGameName, CreateInstance().Name);
        }

        [Fact]
        public void Ctor_Nothing_HomepageTestgameCom()
        {
            Assert.Equal(TestGameHomepage, CreateInstance().Homepage);
        }
    }
}
