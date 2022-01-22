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
    public partial class UC_Additems : UserControl
    {
        //using ServerMain.DBconnect;
    DBconnection connectionn = new DBconnection();
        string stre;
       string keydata = "Chuyến Tàu";
        public UC_Additems()
        {
           InitializeComponent();
          model_Add1.Visible = false;
          model_Add11.Visible = false;
          model_Add21.Visible = false;
        }


        private void UC_Additems_Load(object sender, EventArgs e)
        {
            timer1.Start();
            stre = FmDoashboard.stree2;
           model_Add1.Visible = false; 
           model_Add11.Visible = false;
           model_Add21.Visible = false;
      
           loadInfoChuyentau();
        }

       
            public void loadInfoChuyentau()
            {
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable datasource1 = connectionn0.GetDataEdit(2);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });

                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                guna2DataGridView1.DataSource = datasource1;
            }
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable datasource2 = connectionn1.GetDataEdit(2);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });

                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                guna2DataGridView1.DataSource = datasource2;
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable datasource3 = connectionn2.GetDataEdit(2);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });

                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                guna2DataGridView1.DataSource = datasource3;
            }
              
           
       
            }
        public void loadInfoGaTau()
        {
            
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable datasource = connectionn0.GetDataGaTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Ga tàu", DataPropertyName = "TenGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Ga Tàu", DataPropertyName = "TTGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Ga Tàu", DataPropertyName = "TinhTrangGa" });

                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable datasource = connectionn1.GetDataGaTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Ga tàu", DataPropertyName = "TenGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Ga Tàu", DataPropertyName = "TTGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Ga Tàu", DataPropertyName = "TinhTrangGa" });

                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable datasource = connectionn2.GetDataGaTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Ga tàu", DataPropertyName = "TenGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Ga Tàu", DataPropertyName = "TTGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Ga Tàu", DataPropertyName = "TinhTrangGa" });

                guna2DataGridView1.DataSource = datasource;
            }



        }
        public void loadInfoTau()
        {
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable datasource = connectionn0.GetDataTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Tàu", DataPropertyName = "TTTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Tàu", DataPropertyName = "TT" });

                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable datasource = connectionn1.GetDataTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Tàu", DataPropertyName = "TTTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Tàu", DataPropertyName = "TT" });

                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable datasource = connectionn2.GetDataTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "STT", DataPropertyName = "STT", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Tàu", DataPropertyName = "TTTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Tàu", DataPropertyName = "TT" });

                guna2DataGridView1.DataSource = datasource;
            }


        }
        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            
                 keydata = guna2ComboBox1.Text;
                if (keydata == "Chuyến Tàu")
                {
                model_Add1.Visible = true;
                model_Add1.loadgadi();

                }
                else if (keydata == "Ga Tàu")
                {
                model_Add11.Visible = true;
                }
                else if (keydata == "Tàu")
                {
                model_Add21.Visible = true;
                }
              
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
       
            stre = FmDoashboard.stree2;
     
            if (keydata == "Chuyến Tàu")
            {
                loadInfoChuyentau();
            }
            else if (keydata == "Ga Tàu")
            {
                loadInfoGaTau();
            }
            else if (keydata == "Tàu")
            {
                loadInfoTau();
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            keydata = guna2ComboBox1.Text;
            if (keydata == "Chuyến Tàu")
            {
                loadInfoChuyentau();
            }
            else if (keydata == "Ga Tàu")
            {
                loadInfoGaTau();
            }
            else if (keydata == "Tàu")
            {
                loadInfoTau();
            }
        }
    }
}
