using System.Runtime.Serialization;

namespace RaptoRCon.Games.Dice
{
    /// <summary>
    /// This enum shows the options where a <see cref="IDicePacket"/> command can be originated.
    /// </summary>
    [DataContract]
    public enum PacketOrigin
    {
        /// <summary>
        /// The <see cref="IDicePacket"/> command was originated on the server
        /// </summary>
        [EnumMember]
        Server = 0,

        /// <summary>
        /// The <see cref="IDicePacket"/> command was originated on the client
        /// </summary>
        [EnumMember]
        Client = 1,
    }
}
