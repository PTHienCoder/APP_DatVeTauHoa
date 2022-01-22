using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Main;
using System.Net;
using System.Security.Cryptography;

namespace Client_Demo
{ 
    public partial class UC_SignUp : UserControl
    {
        public string ID;
        public string PASSWORD;
        string a = "BN-01";
        string b = "BN-01";

        public UC_SignUp()
        {
    
            InitializeComponent();
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
  
            if (guna2TextBox3.Text == "" || guna2TextBox4.Text == "" || guna2TextBox5.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ !");
            }
            else if (guna2TextBox4.Text != guna2TextBox5.Text)
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu cho đúng !");
            }
            else
            {
                getDN();
              
            }
        }

        private void getDN()
        {
   
           
            string user = Convert.ToString(guna2TextBox3.Text);
            string pass = Convert.ToString(guna2TextBox4.Text);
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";
            SetInfor_User fm = new SetInfor_User(user, pass);
            fm.Show();
        }
        void client_OnDisconnected(object sender, EventArgs e)
        {
        }

        void client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {
           

      
        }
  
       

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UC_SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
