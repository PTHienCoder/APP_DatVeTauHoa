using Command_Main;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Client_Demo
{
    public partial class SetInfor_User : Form
    {
        private string User;
        private string Pass;
        ClassLibrary.Class1 Object;


        public SetInfor_User(string user, string pass)
        {

            this.User = user;
            this.Pass = pass;
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public SocketClient Client { get; set; }
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


            string Name = Convert.ToString(guna2TextBox1.Text);
            string Adress = Convert.ToString(guna2TextBox2.Text);
            string Phone = Convert.ToString(guna2TextBox3.Text);
            string Email = Convert.ToString(guna2TextBox4.Text);

            var a = Object.dangkykhachhang(User, Pass, Name, Adress, Phone, Email);
            if (a == true)
            {

                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
                guna2TextBox4.Text = "";

                this.Close();
                MessageBox.Show("Đăng ký thành công");

            }
            else

                MessageBox.Show("Đăng ký thất bại");


            this.Close();
        }


        private void SetInfor_User_Load(object sender, EventArgs e)
        {
            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(ClassLibrary.Class1));
            if (entry == null)
            {
                // register
                RemotingConfiguration.RegisterWellKnownClientType(typeof(ClassLibrary.Class1), "http://127.0.0.1:9000/MyObj");
                Object = new ClassLibrary.Class1();
            }

        }

    }
}
