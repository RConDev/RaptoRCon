﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seterlund.CodeGuard;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// An integer. Team 0 is neutral.
    /// </summary>
    /// <remarks>Depending on gamemode, there are up to 16 non-neutral teams, numbered 1…16.</remarks>
    public class TeamId : IDiceWordifyable
    {
        /// <summary>
        /// Gets the <see cref="Int32"/> Team-ID value
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Gets the sign, if the current team id is neutral
        /// </summary>
        public bool IsNeutral { get { return this.Value == 0; } }

        /// <summary>
        /// Creates a new <see cref="TeamId"/> instance
        /// </summary>
        /// <param name="teamId"></param>
        /// <exception cref="ArgumentNullException">If the <paramref name="teamId"/> provided is NULL.</exception>
        public TeamId(string teamId)
        {
            Guard.That(() => teamId).IsNotNull();

            int intValue;
            if (!Int32.TryParse(teamId, out intValue))
            {
                throw new ArgumentOutOfRangeException("teamId");
            }

            if (intValue < 0 || intValue > 16)
            {
                throw new ArgumentOutOfRangeException("teamId");
            }

            Value = intValue;
        }

        /// <summary>
        /// Transforms the current <see cref="TeamId"/> instance into DICE Words
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDiceWord> ToWords()
        {
            yield return new DiceWord(Convert.ToString(this.Value));
        }
    }
}
