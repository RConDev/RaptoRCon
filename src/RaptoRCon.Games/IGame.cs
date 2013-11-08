using System;
using System.Threading.Tasks;

namespace RaptoRCon.Games
{
    /// <summary>
    /// This interface describes the basic element. A Game which can be administered
    /// with RaptoRCon
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Gets the unique identifier of the game within RaptoRCon
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the public / official name of the game
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the official <see cref="Uri"/> to the homepage of the game
        /// </summary>
        Uri Homepage { get; }

        /// <summary>
        /// Gets the factory responsible for creating <see cref="IGameConnection"/> instances for this game
        /// </summary>
        IGameConnectionFactory ConnectionFactory { get; }
    }
}
