using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RaptoRCon.Games.Dice
{
    public class IpPlayerId : PlayerId
    {
        public IPAddress Ip { get; private set; }

        public IpPlayerId(IPAddress ip)
            : base(IdType.Ip)
        {
            #region Contracts

            if (ip == null)
            {
                throw new ArgumentNullException("ip");
            }

            #endregion

            Ip = ip;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords().Concat(IpToWords());
        }

        private IEnumerable<IDiceWord> IpToWords()
        {
            yield return new DiceWord(Ip.ToString());
        }
    }
}