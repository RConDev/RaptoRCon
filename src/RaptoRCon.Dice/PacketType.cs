using System.Runtime.Serialization;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// This enumerations shows the possible options of the current packets function
    /// </summary>
    [DataContract]
    public enum PacketType
    {
        /// <summary>
        /// The current <see cref="IPacket"/> instance is a request.
        /// </summary>
        [EnumMember]
        Request = 0,

        /// <summary>
        /// The current <see cref="IPacket"/> instance is a response.
        /// </summary>
        [EnumMember]
        Response = 1
    }
}
