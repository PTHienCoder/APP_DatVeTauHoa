using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;
using System.Configuration;
using System.IO;


namespace Command_Main
{
    public class Cryptography
    {

        // Ma hoa du lieu
        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            byte[] keyArray;

            using (HashAlgorithm hashAlg = HashAlgorithm.Create("MD5"))
            {
                keyArray = hashAlg.ComputeHash(key);
                hashAlg.Clear();
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(data, 0, data.Length);
            tdes.Clear();

            return resultArray;
        }

        // Giai ma du lieu
        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            byte[] keyArray;

            using (HashAlgorithm hashAlg = HashAlgorithm.Create("MD5"))
            {
                keyArray = hashAlg.ComputeHash(key);
                hashAlg.Clear();
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            int length = 0;
            for (int i = data.Length - 1; i >= 0; i--)
            {
                byte a = data[i];
                if ((int)a != 0)
                {
                    length = i + 1;
                    break;
                }
            }

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(data, 0, length);

            tdes.Clear();
            return resultArray;
        }
    }
}
