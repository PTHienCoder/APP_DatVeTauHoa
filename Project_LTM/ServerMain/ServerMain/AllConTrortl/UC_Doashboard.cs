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
namespace ServerMain.AllConTrortl
{
    public partial class UC_Doashboard : UserControl
    {
        // using ServerMain.DBconnect;
        public SocketServer Server { get; set; }
        string stre;
        public UC_Doashboard()
        {
    
            InitializeComponent();
         
        }
        void socketServer_OnDataReceived(object sender, ReceivedDataEventArgs e)
        { }

       private void UC_Doashboard_Load_1(object sender, EventArgs e)
        {
            stre = FmDoashboard.stree2;
            label1.Text = FmDoashboard.solog.ToString();
            timer1.Start();
            timer2.Start();
            loadInfoChuyentau();
            //view_Details1.Visible = false;
        }
      
        public void loadInfoChuyentau()
        {

        if(stre == "Đà Nẵng")
            {
                DBconnection0 connectionn = new DBconnection0();

                DataTable data = connectionn.GetDataEdit(1);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.GVListTickSystem.AutoGenerateColumns = false;
                this.GVListTickSystem.Columns.Clear();
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Mã chuyến tàu", DataPropertyName = "Machuyentau" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });

                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });

                GVListTickSystem.DataSource = data;
            }
            else if(stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn = new DBconnection1();

                DataTable data = connectionn.GetDataEdit(1);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();

                this.GVListTickSystem.AutoGenerateColumns = false;
                this.GVListTickSystem.Columns.Clear();


                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Mã chuyến tàu", DataPropertyName = "Machuyentau" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });

                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });

                GVListTickSystem.DataSource = data;
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn = new DBconnection2();

                DataTable data = connectionn.GetDataEdit(1);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.GVListTickSystem.AutoGenerateColumns = false;
                this.GVListTickSystem.Columns.Clear();
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Mã chuyến tàu", DataPropertyName = "Machuyentau" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });

                this.GVListTickSystem.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });

                GVListTickSystem.DataSource = data;
            }
    
       
        }
        private void InitializeGrid(object datasource)
        {
          
            if (this.GvListTicketsReceive.InvokeRequired)
            {
                this.GvListTicketsReceive.Invoke(new DlgInitGrid(this.InitializeGrid), new object[] { datasource });
                return;
            }
            DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
            Accept.DataPropertyName = "Accept";
            Accept.UseColumnTextForButtonValue = true;
            Accept.Text = "Check";

            this.GvListTicketsReceive.AutoGenerateColumns = false;
            this.GvListTicketsReceive.Columns.Clear();

            this.GvListTicketsReceive.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDat", Width = 150 });
            this.GvListTicketsReceive.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời Gian", DataPropertyName = "ThoiGianChay", Width = 50 });
            this.GvListTicketsReceive.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số Vé Đặt Mua ", DataPropertyName = "Soluong" });
            this.GvListTicketsReceive.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Loại Ghế", DataPropertyName = "Loaighe", Width = 130 });
          //  this.GvListTicketsReceive.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Người Dùng", DataPropertyName = "TenDangNhap" });
            this.GvListTicketsReceive.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Mã HĐ", DataPropertyName = "MaHD" });
            this.GvListTicketsReceive.Columns.Add(Accept);

            BindingSource source = new BindingSource();
            source.DataSource = datasource;
            this.GvListTicketsReceive.DataSource = datasource;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable data0 = connectionn0.GetOrder();
                InitializeGrid(data0);
            }
            else if (stre == "Hồ Chí Minh")
            {
                label1.Text = "hcm";
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable data1 = connectionn1.GetOrder();
                InitializeGrid(data1);
            }
             else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable data2 = connectionn2.GetOrder();
                InitializeGrid(data2);
            }
      
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            stre = FmDoashboard.stree2;
        }

        private void GvListTicketsReceive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           int Mahd = Convert.ToInt32(GvListTicketsReceive.Rows[e.RowIndex].Cells[4].Value.ToString());
  
              if (e.ColumnIndex == 5)
              {

                  View_Detailss dm = new View_Detailss(Mahd);
                   dm.Server = this.Server;
                   dm.Show();
      


              } 
        }

        private void GVListTickSystem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
