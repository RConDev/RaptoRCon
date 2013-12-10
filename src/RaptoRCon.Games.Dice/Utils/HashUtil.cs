using System;
using System.Security.Cryptography;
using System.Text;

namespace RaptoRCon.Games.Dice.Utils
{


    /// <summary>
    ///     This service is responsible for generating the password hash
    /// </summary>
    public static class HashUtil
    {
        public static HexString GeneratePasswordHash(HexString salt, string password)
        {
            var saltBytes = HashToByteArray(salt.Value);
            var md5Hasher = MD5.Create();

            var combinedPasswordBytes = new byte[saltBytes.Length + password.Length];
            saltBytes.CopyTo(combinedPasswordBytes, 0);
            Encoding.Default.GetBytes(password).CopyTo(combinedPasswordBytes, saltBytes.Length);

            byte[] passwordHash = md5Hasher.ComputeHash(combinedPasswordBytes);
            
            var sbStringifyHash = new StringBuilder();
            foreach (byte t in passwordHash)
            {
                sbStringifyHash.Append(t.ToString("X2"));
            }

            return new HexString(sbStringifyHash.ToString());
        }

        public static byte[] HashToByteArray(string strHexString)
        {
            var a_bReturn = new byte[strHexString.Length / 2];
            for (int i = 0; i < a_bReturn.Length; i++)
            {
                a_bReturn[i] = Convert.ToByte(strHexString.Substring(i * 2, 2), 16);
            }
            return a_bReturn;
        }
    }

}
