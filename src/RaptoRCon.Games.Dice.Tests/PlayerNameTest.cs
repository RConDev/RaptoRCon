﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaptoRCon.Games.Dice.Tests
{
    [ExcludeFromCodeCoverage]
    public class PlayerNameTest
    {
        #region Ctor

        [Fact]
        public void Ctor_null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PlayerName(null));
        }

        [Fact]
        public void Ctor_SamplePlayer_ValueSamplePlayer()
        {
            var playerName = new PlayerName("SamplePlayer");
            Assert.Equal("SamplePlayer", playerName.Value);
        }

        #endregion
    }
}
