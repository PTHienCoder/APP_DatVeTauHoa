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
namespace Client_Demo
{

    public partial class FmBooking : Form
    {
        private int Slveconlai;
        private int Slve;
        private float total;

        private string Tenct;
        private string Gadi;
        private string Gaden;
        private string Thoigianchay;
        private string Ngaydi;
        private int Giave;
        int soluong = 1;
        public SocketClient Client { get; set; }
        public DataTable Datacategory;
        public int IDnguoidung;
        public FmBooking(int soluongve, string tenct, string ngaydi, string thoigiankhoihanh, string Gadi, string Gaden,int idnguoidung, int giave)
        {
            this.Slve = soluongve;
            this.Tenct = tenct;
            this.Ngaydi = ngaydi;
            this.IDnguoidung = idnguoidung;
            this.Gadi = Gadi;
            this.Gaden = Gaden;
            this.Thoigianchay = thoigiankhoihanh;
            this.Giave = giave;
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
        private void Soluongve_ValueChanged(object sender, EventArgs e)
        {
            soluong = Convert.ToInt32(Soluongve.Text);
        

            Slveconlai = Convert.ToInt32(Convert.ToInt32(Slve)-soluong-1);
            label16.Text = Slveconlai.ToString();

            total = Convert.ToInt32(Convert.ToInt32(Giave)*soluong); 
            label6.Text = total.ToString() + ".000 VND";
        }
        private void login_Click(object sender, EventArgs e)
        {
           // int a = Convert.ToInt32(Giave);
            //int b= Convert.ToInt32(this.Soluongve.Value);
           // Tongtien = GiaveConvert.ToInt32(Giave);
            int soluong = Convert.ToInt32(Soluongve.Text);
            string ngaydi = Convert.ToString(label14.Text);
            string thoigianchay = Convert.ToString(label15.Text);
            string Gaden = Convert.ToString(label13.Text);
            string Gadi = Convert.ToString(label11.Text);
            string loaighe = Convert.ToString(LoaiGhe.Text);
            string tongtien = Convert.ToString(label6.Text);
            int slht = Convert.ToInt32(label16.Text);
            // Decimal tongtien = Tongtien;
   


            int idnguoidung = this.IDnguoidung;
            Command_Main.BuyTicketRequest request = new Command_Main.BuyTicketRequest(slht, Tenct, loaighe, soluong, thoigianchay, ngaydi, idnguoidung, Gaden, Gadi, tongtien);
            byte[] data = Command_Main.SerializeHelpers.SerializeData(request);
            Command_Main.Message msg = new Command_Main.Message(Command_Main.Command.Booking, data);
            this.Client.Send(msg.ToMessage());

            string kesearch = "all";
            string ssks = Home.ssk;
            RequestKeySerVer res = new RequestKeySerVer(kesearch, ssks);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.KeySV, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
      
            MessageBox.Show("Thanh toán thành công");
            this.Close();
       
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void FmBooking_Load(object sender, EventArgs e)
        {
            soluong = Convert.ToInt32(Soluongve.Text);

            Slveconlai = Convert.ToInt32(Convert.ToInt32(Slve) - soluong);

            label16.Text = Slveconlai.ToString();
            label12.Text = Tenct;
            label11.Text = Gaden;
            label13.Text = Gadi;
     
    //        Soluongve.Text = "1";
            label15.Text = Convert.ToString(Thoigianchay);
            label14.Text = Convert.ToString(Ngaydi);

            total = Convert.ToInt32(Convert.ToInt32(Giave) * soluong);
            label6.Text = total.ToString() + ".000 VND";
        }

        private void Tentau_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

  
    }
}
