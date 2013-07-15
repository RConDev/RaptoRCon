using System.Collections.Generic;

namespace RaptoRCon.Dice
{
    /// <summary>
    /// This interface describes an object, which can be serialized into a byte array to be transfered to 
    /// a remote host
    /// </summary>
    public interface IDiceSerializableObject
    {
        /// <summary>
        /// Creates a byte[] representation for the <see cref="IDiceSerializableObject"/> instance to communicate 
        /// </summary>
        IEnumerable<byte> ToBytes();
    }
}