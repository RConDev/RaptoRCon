using System;
using System.Threading.Tasks;
using RaptoRCon.Games.Dice.Commands;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Describes how a <see cref="IDiceCommand"/> can be send to the remote rcon instance, while retrieving a direct response.
    /// </summary>
    /// <example>
    /// 
    /// using (var interface = connection.GetCommandInterface())
    /// {
    ///     // Execute the IDiceCommand - here a sample
    ///     var response = interface.ExecuteAsync(new LoginHashedCommand()); 
    /// }
    /// 
    /// </example>
    public interface IDiceCommandInterface : IDisposable
    {
        Task<IDiceCommandResponse> ExecuteAsync(IDiceCommand command);
    }
}