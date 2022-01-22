using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Command_Main
{
    public class SerializeHelpers
    {

        public static byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            byte[] byteData = ms.ToArray();
            // byte[] byteData = SGCommon.cryphytion.Encrypt(ms.ToArray(), true);
            return byteData;
        }

        public static object DeserializeData(byte[] theByteArray)
        {
            // byte[] data = SGCommon.cryphytion.Decrypt(theByteArray,true);

            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();

            return bf1.Deserialize(ms);
        }
        public static string GetKey()
        {
            System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("SecurityDB", typeof(String));

            return key;
        }
    }
}
