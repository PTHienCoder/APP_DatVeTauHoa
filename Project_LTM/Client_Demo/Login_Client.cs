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
using System.Net.Sockets;

namespace Client_Demo
{
    public partial class Login_Client : Form
    {
        public SocketClient Client { get; set; }
        public string ID;
        public string PASSWORD;
        public string KEYSV;
        public static string keySVer;
        public Login_Client(string id, string pass, string Keysv)
        {
            this.KEYSV = Keysv;
            this.ID = id;
             this.PASSWORD = pass;
            InitializeComponent();
        }

        private void Login_Client_Load(object sender, EventArgs e)
        {
            keySVer = guna2ComboBox1.Text;
            CheckForIllegalCrossThreadCalls = false;
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";

            ID = guna2TextBox1.Text;
            PASSWORD = guna2TextBox2.Text;
            uC_SignUp1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            guna2Transition1.ShowSync(uC_SignUp1);
            uC_SignUp1.Visible = true;
            uC_SignUp1.BringToFront();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            string ipadress = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                .ToString();
            IPAddress ipAddress = IPAddress.Parse(ipadress);
            int port = 1000;

            Client = new SocketClient();
            Client.OnConnected += client_OnConnected; // tao ra cac co thong bao cho client
            Client.OnDisconnected += client_OnDisconnected;
            Client.OnDataReceived += client_OnDataReceived;
            Client.Connect(ipAddress, port);
            keySVer = guna2ComboBox1.Text;

        }

        private void Login()
        {
            string id = this.guna2TextBox1.Text;
            string pass = this.guna2TextBox2.Text;
            string keysv = this.guna2ComboBox1.Text;
             this.ID = id;
             this.PASSWORD = pass;
           this.KEYSV = keysv;

            Command_Main.LoginRequest request = new Command_Main.LoginRequest(id, pass);
            byte[] data = Command_Main.SerializeHelpers.SerializeData(request);
            Command_Main.Message msg = new Command_Main.Message(Command_Main.Command.Login, data);
            this.Client.Send(msg.ToMessage());
          
        }
        
        void client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {
            Command_Main.Message responseMessage = Command_Main.Message.Parse(e.Data);
            switch (responseMessage.Command)
            {
                case Command.RequestCertificate:
                    var certificateResponse = (Command_Main.CertificateResponse)Command_Main.SerializeHelpers.DeserializeData(responseMessage.DataByte);
                    this.Client.State.Certificate.PublicKey = certificateResponse.PublicKey;
                    this.Client.State.Certificate.ShareKey = SecureEncryption_server.GenerateSharedKey(this.Client.State.Certificate.PublicKey);
                    var encryptedSharedKey = SecureEncryption_server.EncryptedShareKey(this.Client.State.Certificate.ShareKey, this.Client.State.Certificate.PublicKey);
                    SharedKeyRequest shareKeyRequest = new SharedKeyRequest() { RequestTime = DateTime.Now, SharedKey = encryptedSharedKey };
                    var shareKeyMessage = new Command_Main.Message(Command.SendSharedKey, SerializeHelpers.SerializeData(shareKeyRequest));
                    this.Client.Send(shareKeyMessage.ToMessage(), false);
                    break;
                case Command.SendSharedKey:
                    Login();
                    break;
               
                case Command_Main.Command.Login:
                    var loginResponse = (Command_Main.LoginResponse)Command_Main.SerializeHelpers.DeserializeData(responseMessage.DataByte);

                    if (loginResponse.Success == true)
                    {
                        Client.OnConnected -= client_OnConnected; // tao ra cac co thong bao cho client
                        Client.OnDisconnected -= client_OnDisconnected;
                        Client.OnDataReceived -= client_OnDataReceived;

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                        this.Close();
                
                    }
                    else

                        MessageBox.Show("Đăng nhập thất bại");

                    break;

            }
        }

    

        void client_OnDisconnected(object sender, EventArgs e)
        {
            MessageBox.Show("disconnected");
        }
        static private RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
        static private RSAParameters privKey_client = csp.ExportParameters(true);

        void client_OnConnected(object sender, EventArgs e)
        {
            InitCertificate();
        }

        private void InitCertificate()
        {
            CertificateRequest request = new CertificateRequest() { };
            Command_Main.Message msg = new Command_Main.Message(Command.RequestCertificate, SerializeHelpers.SerializeData(request));
            this.Client.Send(msg.ToMessage(), false);
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keySVer = guna2ComboBox1.Text;
        }
    }
}
