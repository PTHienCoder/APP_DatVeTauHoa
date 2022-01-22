using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Command_Main
{
    public class Encrypt_Decrypt_DataBase
    {

        // Mã hóa ký tự với kiểu mã hõa TripleDes - MD5  
        public static string DataBase_Encrypt(string key, string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncrypt_PlainText_Array = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                using (HashAlgorithm hashAlg = HashAlgorithm.Create("MD5"))
                {
                    keyArray = hashAlg.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashAlg.Clear();
                }
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncrypt_PlainText_Array, 0, toEncrypt_PlainText_Array.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        // Giải mã dữ liệu đã mã hóa 

        public static string DataBase_Decrypt(string key, string toDecrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                using (HashAlgorithm hashAlg = HashAlgorithm.Create("MD5"))
                {
                    keyArray = hashAlg.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashAlg.Clear();
                }
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
