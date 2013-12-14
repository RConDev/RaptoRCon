using System;
using System.Collections.Generic;
using System.Net;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// A string on the following format: <IPv4 address>:<port number>
    /// </summary>
    public class IpPortPair : IDiceWordifyable
    {
        private readonly IPAddress ipAddress;
        private readonly ushort port;

        public IpPortPair(IPAddress ipAddress, UInt16 port)
        {
            Guard.That(() => ipAddress).IsNotNull();
            Guard.That(() => port).IsGreaterThan(Convert.ToUInt16(0));
            
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public IEnumerable<IDiceWord> ToWords()
        {
            var wordContent = string.Format("{0}:{1}", ipAddress, port);
            yield return new DiceWord(wordContent);
        }
    }
}