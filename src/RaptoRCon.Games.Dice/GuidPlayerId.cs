using System;
using System.Collections.Generic;
using System.Linq;

namespace RaptoRCon.Games.Dice
{
    public class GuidPlayerId : PlayerId
    {
        public DiceGuid Guid { get; private set; }

        public GuidPlayerId(DiceGuid guid)
            : base(IdType.Guid)
        {
            #region Contracts

            if (guid == null)
            {
                throw new ArgumentNullException("guid");
            }

            #endregion

            this.Guid = guid;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords().Concat(Guid.ToWords());
        }
    }
}