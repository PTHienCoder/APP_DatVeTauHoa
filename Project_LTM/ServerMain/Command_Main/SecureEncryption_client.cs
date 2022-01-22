using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Command_Main
{
    public class SecureEncryption_client
    {
        static private RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
        static private RSAParameters privKey_client = csp.ExportParameters(true);
        //static public RSAParameters  pubKey_client = csp.ExportParameters(false);
        public static RSAParameters PubkeyClient()
        {
            RSAParameters pubKey_client = csp.ExportParameters(false);
            return pubKey_client;
        }

        public static string EncryData(string plainTextData, RSAParameters pubKey_server)
        {

            csp.ImportParameters(pubKey_server);// import pubkey vao de su dung encrypt

            //chuyen string sang byte
            byte[] bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);

            // encrypt data 
            byte[] bytesCipherText = csp.Encrypt(bytesPlainTextData, false);

            // chuyen byte sang string
            string cipherText = Convert.ToBase64String(bytesCipherText);

            return cipherText;
        }

        public static string DecryData(string CipherText)
        {
            // chuyen string sang byte
            byte[] bytesCipherText = Convert.FromBase64String(CipherText);

            // import privkey vao de su dung Decrypt
            csp.ImportParameters(privKey_client);

            //decrypt data
            byte[] bytesPlainTextData = csp.Decrypt(bytesCipherText, false);

            //chuyen byte sang lai string
            string plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

            return plainTextData;
        }
    }
}
