using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Command_Main
{
    public sealed class SessionKey
    {
        public RSAParameters PublicKey;
        public RSAParameters PrivateKey;
        public byte[] ShareKey;

        public bool HasPublicKey { get { return !this.PublicKey.Equals(default(RSAParameters)); } }
        public bool HasPrivateKey { get { return !this.PrivateKey.Equals(default(RSAParameters)); } }
        public bool PublicKeySent { get; set; }
        public bool SharedKeyReceived { get; set; }

        public SessionKey() { }
        //Download source code FREE tai Sharecode.vn
        public SessionKey(RSAParameters publicKey, RSAParameters privateKey)
        {
            this.PublicKey = publicKey;
            this.PrivateKey = privateKey;
        }
    }

    public class SecureEncryption_server
    {
        public static SessionKey GenerateSessionKey()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                return new SessionKey(rsa.ExportParameters(false), rsa.ExportParameters(true));
            }
        }

        public static byte[] GenerateSharedKey(RSAParameters publicKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;
                return aes.Key;
            }
        }

        public static byte[] EncryptedShareKey(byte[] sharedKey, RSAParameters publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(sharedKey, true);
            }
        }

        public static byte[] DecryptShareKey(RSAParameters privateKey, byte[] encryptedSharedKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                return rsa.Decrypt(encryptedSharedKey, true);
            }
        }
    }
}
