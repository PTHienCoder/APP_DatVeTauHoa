using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
namespace Command_Main
{
    public class Message
    {
        public Command Command { get; set; }

        public byte[] DataByte { get; set; }

        public Message(Command command, byte[] data)
        {
            this.Command = command;
            this.DataByte = data;
        }

        public byte[] ToMessage()
        {
            byte[] buffer = new byte[this.DataByte.Length + 1];
            buffer[0] = Convert.ToByte(this.Command);
            Array.Copy(this.DataByte, 0, buffer, 1, this.DataByte.Length);
            return buffer;
        }

        public static Message Parse(byte[] data)
        {
            Command cmd = (Command)data[0];
            byte[] dataByte = new byte[data.Length - 1];
            Array.Copy(data, 1, dataByte, 0, dataByte.Length);
            Message msg = new Message(cmd, dataByte);
            return msg;
        }
    }

    public class Data
    {
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
        }

        public Data(byte[] data)
        {
            this.cmdCommand = (Command)data[0];
            this.DataByte = new byte[data.Length - 1];
            Array.Copy(data, 1, this.DataByte, 0, this.DataByte.Length);

            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);


            int nameLen = BitConverter.ToInt32(data, 4);

            int msgLen = BitConverter.ToInt32(data, 8);


            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;


            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }


        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();


            result.AddRange(BitConverter.GetBytes((int)cmdCommand));


            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));


            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));


            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));


            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);

        }
        public string strName;
        public string strMessage;
        public Command cmdCommand { get; set; }
        public byte[] DataByte { get; set; }
    }
}
