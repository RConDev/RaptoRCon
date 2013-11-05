using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Battlefield4.Tests
{
    public class Battlefield4Test
    {
        private static Battlefield4 CreateInstance()
        {
            return new Battlefield4();
        }

        [Fact]
        public void Ctor_Nothing_IdEF9AB333_4AA7_488C_A6BF_FA5E5E3357C1() 
        { 
            Assert.Equal(Battlefield4.GameId, CreateInstance().Id);
        }

        [Fact]
        public void Ctor_Nothing_NameBattlefield4()
        {
            Assert.Equal(Battlefield4.GameName, CreateInstance().Name);
        }

        [Fact]
        public void Ctor_Nothing_Homepagehttp___www_battlefield_com_battlefield_4()
        {
            Assert.Equal(new Uri("http://www.battlefield.com/battlefield-4"), CreateInstance().Homepage);
        }
    }
}
