namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// Represents all options how players can be identified.
    /// </summary>
    public enum IdType
    {
        None, 

        /// <summary>
        /// The player is identified by its unique player name
        /// </summary>
        Name,
        
        /// <summary>
        /// The player is identified by its current IpAddress he is currently using
        /// </summary>
        Ip,

        /// <summary>
        /// The player is identified by its unique EA_{*} GUID
        /// </summary>
        Guid
    }
}