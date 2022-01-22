using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace Command_Main
{
    public delegate void OnConnectedEventHandler(object sender, EventArgs e);

    public delegate void OnDisconnectedEventHandler(object sender, EventArgs e);

    public delegate void OnReceivedEventHandler(object sender, ReceivedDataEventArgs e);

    public class ReceivedDataEventArgs : EventArgs
    {
        public string SocketKey { get; set; }

        public byte[] Data { get; set; }
    }

    public class CommunicationState
    {
        public byte[] Data { get; set; }

        public Socket Socket { get; set; }

        public string Key { get; set; }

        public int MaKH { get; set; }

        public SessionKey Certificate { get; set; }
    }

    public class SocketOptions
    {
        public static bool NeedEncrypt(Command command)
        {
            switch (command)
            {
                case Command.RequestCertificate:
                case Command.SendSharedKey:
                    return false;
                default:
                    return true;
            }
        }
    }

    public enum Command
    {
        KeySV, // key server
        HictoryVT, // lịch sử đặt vé
        DeleteVT, // key server
        send_gadi,
        send_gaden,
        search,
        Login,      //dag nhap
        Logout,     //dang xuat
        Message,    //thong diep
        List,       //lay danh sach client
        recData,    //nhan datatu server
        sendData,   // giu data cho server
        discon,     // ngat ket noi với 1 clent
        Null,      //No command,
        Booking,
        sendInfouser,
        changeInfoUser,
        bookingt,
        Historybooking,
        RequestCertificate,
        SendSharedKey
    }
}
