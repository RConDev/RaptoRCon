using System;
using System.Collections.Generic;
using System.Linq;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice
{
    public class GuidPlayerId : PlayerId
    {
        public DiceGuid Guid { get; private set; }

        public GuidPlayerId(DiceGuid guid)
            : base(IdType.Guid)
        {
            Guard.That(() => guid).IsNotNull();

            Guid = guid;
        }

        public override IEnumerable<IDiceWord> ToWords()
        {
            return base.ToWords().Concat(Guid.ToWords());
        }
    }
}