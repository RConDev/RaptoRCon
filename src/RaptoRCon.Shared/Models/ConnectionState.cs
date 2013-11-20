namespace RaptoRCon.Shared.Models
{
    /// <summary>
    /// Describes the current state of a connection to a game
    /// </summary>
    public enum ConnectionState
    {
        /// <summary>
        /// The connection has not been established
        /// </summary>
        NotConnected,
        
        /// <summary>
        /// The connection has successfully been established
        /// </summary>
        Connected
    }
}