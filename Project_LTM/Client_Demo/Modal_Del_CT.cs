using Command_Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Demo
{
    public partial class Modal_Del_CT : Form
    {
        string MaHD, myname;
        int id;
        public SocketClient Client { get; set; }
        public Modal_Del_CT(string mahd, string myname, int id)
        {
            this.MaHD = mahd;
            this.myname = myname;
            this.id = id;
            InitializeComponent();
        }
        public void SetClient(SocketClient client)
        {
            this.Client = client;
            this.Client.OnDataReceived += Client_OnDataReceived;
            this.Client.OnDisconnected += Client_OnDisconnected;
        }

        void Client_OnDisconnected(object sender, EventArgs e)
        {

        }

        void Client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {
        }
        
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Command_Main.DeleteBookingRequest request = new Command_Main.DeleteBookingRequest(MaHD);
            byte[] data = Command_Main.SerializeHelpers.SerializeData(request);
            Command_Main.Message msg = new Command_Main.Message(Command_Main.Command.DeleteVT, data);
            this.Client.Send(msg.ToMessage());
            MessageBox.Show("Huỷ thành công");
            this.Close();


            SendRequestHistoty res = new SendRequestHistoty(id);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.HictoryVT, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }

        private void Modal_Del_CT_Load(object sender, EventArgs e)
        {

        }
    }
}
