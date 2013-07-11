using System.Runtime.Serialization;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// This enum shows the options where a <see cref="IPacket"/> command can be originated.
    /// </summary>
    [DataContract]
    public enum PacketOrigin
    {
        /// <summary>
        /// The <see cref="IPacket"/> command was originated on the server
        /// </summary>
        [EnumMember]
        Server = 0,

        /// <summary>
        /// The <see cref="IPacket"/> command was originated on the client
        /// </summary>
        [EnumMember]
        Client = 1,
    }
}
