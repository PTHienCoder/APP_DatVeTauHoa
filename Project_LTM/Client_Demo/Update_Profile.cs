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
    public partial class Update_Profile : Form
    {
        public SocketClient Client { get; set; }
        int id;
        string name, phone, adress, mail, Id, Pass;
        public Update_Profile(int ID,  string Name, string Phone, string Adress, string email, string Id, string Pass)
        {
            this.id = ID;
            this.name = Name;
            this.phone = Phone;
            this.adress = Adress;
            this.mail = email;
            this.Id = Id;
            this.Pass = Pass;
            InitializeComponent();
        }

        private void Update_Profile_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = name;
            guna2TextBox2.Text = adress;
            guna2TextBox3.Text = phone;
            guna2TextBox4.Text = mail;
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
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string Nameu = guna2TextBox1.Text;
            string adressu = guna2TextBox2.Text;
            string phoneu = guna2TextBox3.Text;
            string mailu = guna2TextBox4.Text ;
            Command_Main.UpdateProfile_Request request = new Command_Main.UpdateProfile_Request(id, Nameu, phoneu, adressu, mailu);
            byte[] data = Command_Main.SerializeHelpers.SerializeData(request);
            Command_Main.Message msg = new Command_Main.Message(Command_Main.Command.changeInfoUser, data);
            this.Client.Send(msg.ToMessage());
            MessageBox.Show("Thay đổi thành công");
            this.Close();

            SendInfUserRequest requestinfuser = new SendInfUserRequest(Id, Pass);
            Command_Main.Message message_infouser = new Command_Main.Message(Command_Main.Command.sendInfouser, SerializeHelpers.SerializeData(requestinfuser));
            this.Client.Send(message_infouser.ToMessage());
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
