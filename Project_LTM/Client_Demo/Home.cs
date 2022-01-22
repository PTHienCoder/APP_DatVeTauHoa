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
using System.Runtime.Remoting;
using ClassLibrary;
using Guna.UI2.WinForms;

namespace Client_Demo
{
    public delegate void DlgInitGrid(object datasource);
    public partial class Home : Form
    {
        ClassLibrary.Class1 Object;

        public DataTable Data_category;
        private string Id;
        private string Pass;
        private string Keysv = Login_Client.keySVer;
        private int ID;
        string Myname;
        private string user, pass, name, adress, phone, sodu, email;
        DataTable DataUserInfo;
        public static string ssk;
        string keysearch = "all";
        public SocketClient Client { get; set; }
        public Home()
        {

            Login_Client loginForm = new Login_Client(Id, Pass, Keysv);
            SetInfor_User sn = new SetInfor_User(user, pass);
            if (loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Id = loginForm.ID;
                this.Pass = loginForm.PASSWORD;
                this.Keysv = loginForm.KEYSV;
                this.SetClient(loginForm.Client);

                this.InitializeComponent();
              

                RequestKeySerVer res = new RequestKeySerVer(keysearch, Keysv);
                Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.KeySV, SerializeHelpers.SerializeData(res));
                this.Client.Send(ms.ToMessage());
                /*
                SendRequest_Gadi ress = new SendRequest_Gadi();
                Command_Main.Message mss = new Command_Main.Message(Command_Main.Command.send_gadi, SerializeHelpers.SerializeData(ress));
                this.Client.Send(mss.ToMessage());*/
            }

            else
            {
                Application.Exit();
            }

        }

        public void SetClient(SocketClient client)
        {
            this.Client = client;
            this.Client.OnDataReceived += Client_OnDataReceived;
            this.Client.OnDisconnected += Client_OnDisconnected;
        }

        private delegate void SetDSDelegate(Guna2DataGridView grid, object source);

        private void SetDataSource(Guna2DataGridView dataGridView, object dataSource)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new SetDSDelegate(this.SetDataSource), new object[] { dataGridView, dataSource });
                return;
            }
            dataGridView.BindingContext = this.BindingContext;
            dataGridView.DataSource = dataSource;
        }

        void Client_OnDisconnected(object sender, EventArgs e)
        {
            MessageBox.Show("disconnected");
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void Client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {
            Command_Main.Message messageResponse = Command_Main.Message.Parse(e.Data);

            switch (messageResponse.Command)
            {

                case Command_Main.Command.Booking:
                    break;

                case Command_Main.Command.bookingt:

                    var bookresponse = (Command_Main.Booking_Response_t)Command_Main.SerializeHelpers.DeserializeData(messageResponse.DataByte);

                    if (bookresponse.Success == true)
                    {
                        MessageBox.Show("Mua vé thành công");

                    }
                    break;


                case Command_Main.Command.sendData:

                    SendInfoTicketResponse sendInfoResponse = (SendInfoTicketResponse)SerializeHelpers.DeserializeData(messageResponse.DataByte);
            /*      DataTable Data1 = new DataTable();
                    Data1.Columns.Add("TenChuyenTau");
                    Data1.Columns.Add("NgayDi");
                    Data1.Columns.Add("ThoiGianChay");
                    Data1.Columns.Add("TenGaDi");
                    Data1.Columns.Add("SoVeToiDa");
                    Data1.Columns.Add("TenGaDen");
                    Data1.Columns.Add("GiaVe");

              
                
                    for (int i = 0; i < sendInfoResponse.Items.Length; i++)
                    {
                        if (sendInfoResponse.Items[i].Soluongvetau > 0)
                        {
                            DataRow newRow = Data1.NewRow();

                            newRow["TenChuyenTau"] = sendInfoResponse.Items[i].TenChuyentau;
                            newRow["NgayDi"] = sendInfoResponse.Items[i].Ngaydi;
                            newRow["ThoiGianChay"] = sendInfoResponse.Items[i].ThoiGianChay;
                            newRow["TenGaDi"] = sendInfoResponse.Items[i].GaDi;
                            newRow["SoVeToiDa"] = sendInfoResponse.Items[i].Soluongvetau;
                            newRow["TenGaDen"] = sendInfoResponse.Items[i].GaDen;
                            newRow["GiaVe"] = sendInfoResponse.Items[i].Giave;

                            Data1.Rows.Add(newRow);
                        }
                    }
                    Data1.AcceptChanges();
                  InitializeGrid(Data1);*/
                
                     flowLayoutPanel2.Controls.Clear();

                         IteamVeTau[] lisits = new IteamVeTau[sendInfoResponse.Items.Length];
                      //   UserControl1[] lisits2 = new UserControl1[sendInfoResponse.Items.Length];
                    for (int i = 0; i < sendInfoResponse.Items.Length; i++) { 
                     
                            flowLayoutPanel2.Invoke((MethodInvoker)delegate {               
                                lisits[i] = new IteamVeTau();
                            //     lisits2[i] = new UserControl1();


                                lisits[i].NameCT = sendInfoResponse.Items[i].TenChuyentau;
                                lisits[i].Gadi = sendInfoResponse.Items[i].GaDi;
                                lisits[i].Gaden = sendInfoResponse.Items[i].GaDen;
                                lisits[i].Thoigian = sendInfoResponse.Items[i].ThoiGianChay;
                                lisits[i].Ngay = sendInfoResponse.Items[i].Ngaydi;
                                lisits[i].Slveconlai = sendInfoResponse.Items[i].Soluongvetau;
                                lisits[i].Giave = sendInfoResponse.Items[i].Giave;
                                
                                flowLayoutPanel2.Controls.Add(lisits[i]);
                       
                                lisits[i].Click += new System.EventHandler(this.usercontrol_click);
                            });
 
                        }
                    break;
                case Command_Main.Command.sendInfouser:

                    SendInfUserResponse sendUserResponse = (SendInfUserResponse)SerializeHelpers.DeserializeData(messageResponse.DataByte);
                    for (int i = 0; i < sendUserResponse.Items.Length; i++)
                    {
                   
                        Myname = sendUserResponse.Items[i].TenDayDu;
                        label8.Text = sendUserResponse.Items[i].Tendangnhap;
                        label12.Text = sendUserResponse.Items[i].Matkhau;
                        label10.Text = sendUserResponse.Items[i].Sodienthoai;
                        label11.Text = sendUserResponse.Items[i].Diachi;

                        label14.Text = sendUserResponse.Items[i].Sotien + "$";
                        label13.Text = sendUserResponse.Items[i].TenDayDu;

                        label16.Text = sendUserResponse.Items[i].Email;

                        this.ID = sendUserResponse.Items[i].Id;
                        this.phone = sendUserResponse.Items[i].Sodienthoai;
                        this.adress = sendUserResponse.Items[i].Diachi;
                        this.name = sendUserResponse.Items[i].TenDayDu;
                        this.email = sendUserResponse.Items[i].Email;
                        this.sodu = sendUserResponse.Items[i].Sotien;
                        this.pass = sendUserResponse.Items[i].Matkhau;
                        this.user = sendUserResponse.Items[i].Tendangnhap;

                    }


                    break;
                case Command_Main.Command.send_gadi:
                    /*
                    SenReponse_Gadi bookresponsegadi = (SenReponse_Gadi)Command_Main.SerializeHelpers.DeserializeData(messageResponse.DataByte);

                    guna2ComboBox3.DisplayMember = "TenGaTau";
                    guna2ComboBox3.ValueMember = "id";
                    guna2ComboBox3.DataSource = bookresponsegadi.name;*/
                    break;

                case Command_Main.Command.search:

                    SendRepone_Search sendInfoResponsearch = (SendRepone_Search)SerializeHelpers.DeserializeData(messageResponse.DataByte);
         
                    
                    flowLayoutPanel2.Controls.Clear();

                    IteamVeTau[] lisitserch = new IteamVeTau[sendInfoResponsearch.Itemseach.Length];
                    for (int i = 0; i < sendInfoResponsearch.Itemseach.Length; i++)
                    {

                        flowLayoutPanel2.Invoke((MethodInvoker)delegate {
                            lisitserch[i] = new IteamVeTau();
                            //     lisits2[i] = new UserControl1();


                            lisitserch[i].NameCT = sendInfoResponsearch.Itemseach[i].TenChuyentau;
                            lisitserch[i].Gadi = sendInfoResponsearch.Itemseach[i].GaDi;
                            lisitserch[i].Gaden = sendInfoResponsearch.Itemseach[i].GaDen;
                            lisitserch[i].Thoigian = sendInfoResponsearch.Itemseach[i].ThoiGianChay;
                            lisitserch[i].Ngay = sendInfoResponsearch.Itemseach[i].Ngaydi;
                            lisitserch[i].Slveconlai = sendInfoResponsearch.Itemseach[i].Soluongvetau;
                            lisitserch[i].Giave = sendInfoResponsearch.Itemseach[i].Giave;
                            flowLayoutPanel2.Controls.Add(lisitserch[i]);

                            lisitserch[i].Click += new System.EventHandler(this.usercontrol_click);
                        });

                    }
                    break;



            }


            // Read rows from DataReader and populate the DataTable
        }
        private void iteamVeTau1_Click(object sender, EventArgs e)
        {
            if (!flowLayoutPanel2.Controls.Contains(IteamVeTau.Instance))
            {
                flowLayoutPanel2.Controls.Add(IteamVeTau.Instance);
                IteamVeTau.Instance.Dock = DockStyle.Fill;
                IteamVeTau.Instance.BringToFront();
            }
            else
                IteamVeTau.Instance.BringToFront();
        }
        private void usercontrol_click(object sender, EventArgs e)
        {
            IteamVeTau obj = (IteamVeTau)sender;
            string tenct = Convert.ToString(obj.NameCT.ToString());
            string ngaydi = Convert.ToString(obj.Ngay.ToString());
            string thoigiankhoihanh = Convert.ToString(obj.Thoigian.ToString());

            string gadi = Convert.ToString(obj.Gadi.ToString());
            string gaden = Convert.ToString(obj.Gaden.ToString());
            int result = Int32.Parse(obj.Giave);
            string soluon = Convert.ToString(obj.Slveconlai.ToString());
            int soluongve = Int32.Parse(soluon);

            FmBooking fr = new FmBooking(soluongve, tenct, ngaydi, thoigiankhoihanh, gadi, gaden, ID, result);
            ssk = guna2ComboBox1.Text;
            fr.SetClient(this.Client);
            fr.Show();
        }

        private void InitializeGrid(object datasource)
        {

            /*
            if (this.GvListTicketCT.InvokeRequired)
            {
                this.GvListTicketCT.Invoke(new DlgInitGrid(this.InitializeGrid), new object[] { datasource });
                return;
            }
            DataGridViewButtonColumn sella = new DataGridViewButtonColumn();
            sella.DataPropertyName = "Sell";
            sella.UseColumnTextForButtonValue = true;
            sella.Text = "Mua Vé";

            this.GvListTicketCT.AutoGenerateColumns = false;
            this.GvListTicketCT.Columns.Clear();

            this.GvListTicketCT.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Chuyến Tàu", DataPropertyName = "TenChuyenTau" });
            this.GvListTicketCT.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
            this.GvListTicketCT.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "ThoiGianChay" });
            this.GvListTicketCT.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ga Đi", DataPropertyName = "TenGaDi" });
            this.GvListTicketCT.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ga Đến", DataPropertyName = "TenGaDen" });
            this.GvListTicketCT.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Giá vé", DataPropertyName = "GiaVe" });
            this.GvListTicketCT.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng còn lại", DataPropertyName = "SoVeToiDa" });
            this.GvListTicketCT.Columns.Add(sella);

          //  this.GvListTicketCT.DataSource = Data1;


            BindingSource source = new BindingSource();
            source.DataSource = datasource;
            this.GvListTicketCT.DataSource = datasource;
            */
        }


  


        private void Home_Load(object sender, EventArgs e)
        {

            WellKnownClientTypeEntry entry = RemotingConfiguration.IsWellKnownClientType(typeof(ClassLibrary.Class1));
            if (entry == null)
            {
                // register
                RemotingConfiguration.RegisterWellKnownClientType(typeof(ClassLibrary.Class1), "http://127.0.0.1:9000/MyObj");
                Object = new ClassLibrary.Class1();
            }

            guna2ComboBox1.Text = Login_Client.keySVer;
            SendInfUserRequest requestinfuser = new SendInfUserRequest(Id, Pass);
            Command_Main.Message message_infouser = new Command_Main.Message(Command_Main.Command.sendInfouser, SerializeHelpers.SerializeData(requestinfuser));
            this.Client.Send(message_infouser.ToMessage());

            /*
                 SendInfoTicketRequest res = new SendInfoTicketRequest();
                 Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.sendData, SerializeHelpers.SerializeData(res));
                 this.Client.Send(ms.ToMessage());



                SendRequest_Gadi ress = new SendRequest_Gadi();
                Command_Main.Message mss = new Command_Main.Message(Command_Main.Command.send_gadi, SerializeHelpers.SerializeData(ress));
                this.Client.Send(mss.ToMessage());
              */
            guna2ComboBox2.DisplayMember = "TenGaTau";
            guna2ComboBox2.ValueMember = "id";
            guna2ComboBox2.DataSource = Object.GetGa();
            loadGaddi();
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keysearch = "all";

            string ssks = Convert.ToString(guna2ComboBox1.Text.ToString());
            RequestKeySerVer res = new RequestKeySerVer(keysearch, ssks);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.KeySV, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());


            SendRequest_Gadi ress = new SendRequest_Gadi();
            Command_Main.Message mss = new Command_Main.Message(Command_Main.Command.send_gadi, SerializeHelpers.SerializeData(ress));
            this.Client.Send(mss.ToMessage());

        } 
       
        public void loadGaddi()
        {
            if (Keysv == "Đà Nẵng")
            {
                guna2ComboBox3.DisplayMember = "TenGaTau";
                guna2ComboBox3.ValueMember = "id";
                guna2ComboBox3.DataSource = Object.GetGa0();
            }
            else if (Keysv == "Hồ Chí Minh")
            {
                guna2ComboBox3.DisplayMember = "TenGaTau";
                guna2ComboBox3.ValueMember = "id";
                guna2ComboBox3.DataSource = Object.GetGa1();
            }
            else if (Keysv == "Hà Nội")
            {
                guna2ComboBox3.DisplayMember = "TenGaTau";
                guna2ComboBox3.ValueMember = "id";
                guna2ComboBox3.DataSource = Object.GetGa2();
            }
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
    // button load

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
   
        
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string ssks = Convert.ToString(guna2ComboBox1.Text.ToString());
            RequestKeySerVer res = new RequestKeySerVer(keysearch, ssks);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.KeySV, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());


            HistoryBooking ds = new HistoryBooking(Myname, ID);
            ds.SetClient(this.Client);
            ds.Show();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            Update_Profile fr = new Update_Profile(ID, name, phone, adress, email, Id, Pass);
            fr.SetClient(this.Client);
            fr.Show();
        }

        private void GvListTicketCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            string tenct = Convert.ToString(GvListTicketCT.Rows[e.RowIndex].Cells[0].Value.ToString());
            string ngaydi = Convert.ToString(GvListTicketCT.Rows[e.RowIndex].Cells[1].Value.ToString());
            string thoigiankhoihanh = Convert.ToString(GvListTicketCT.Rows[e.RowIndex].Cells[2].Value.ToString());

            string gadi = Convert.ToString(GvListTicketCT.Rows[e.RowIndex].Cells[3].Value.ToString());
            string gaden = Convert.ToString(GvListTicketCT.Rows[e.RowIndex].Cells[4].Value.ToString());
            int giave = Convert.ToInt32(GvListTicketCT.Rows[e.RowIndex].Cells[5].Value.ToString());
            string soluon = Convert.ToString(GvListTicketCT.Rows[e.RowIndex].Cells[6].Value.ToString());
            int soluongve = Int32.Parse(soluon);
            if (e.ColumnIndex == 7)
            {
                FmBooking fr = new FmBooking(soluongve, tenct, ngaydi, thoigiankhoihanh, gadi, gaden, ID, giave);
                ssk = guna2ComboBox1.Text;
                fr.SetClient(this.Client);
                fr.Show();
            }
            else
            {

            }*/
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

            
          

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// loc gadi
            keysearch = guna2ComboBox3.Text;

            SendRequest_Search res = new SendRequest_Search(keysearch);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///loc gadden
            keysearch = guna2ComboBox2.Text;
            SendRequest_Search res = new SendRequest_Search(keysearch);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
 
          
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            keysearch = "all";

            string ssks = Convert.ToString(guna2ComboBox1.Text.ToString());
            RequestKeySerVer res = new RequestKeySerVer(keysearch, ssks);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.KeySV, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            keysearch = guna2DateTimePicker1.Text;

            SendRequest_Search res = new SendRequest_Search(keysearch);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            keysearch = guna2ComboBox4.Text;

            SendRequest_Search res = new SendRequest_Search(keysearch);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }

        private void iteamVeTau1_Load(object sender, EventArgs e)
        {

        }

  

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tbTenchuyentau_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {


        }


    }
}
