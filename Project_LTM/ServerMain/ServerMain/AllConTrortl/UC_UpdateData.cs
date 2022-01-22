using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMain.AllConTrortl
{
    public partial class UC_UpdateData : UserControl
    {

        //using ServerMain.DBconnect;
        DBconnection connectionn = new DBconnection();
        string stre;
        string keydata = "Hoá Đơn";
        string tenCT;
        string keytrangthai = "New";
        public UC_UpdateData()
        {
            InitializeComponent();
        }
        private void UC_Additems_Load(object sender, EventArgs e)
        {
            timer1.Start();
            stre = FmDoashboard.stree2;
            loadInfoHD();
        }


        public void loadInfoChuyentau()
        {
            guna2DataGridView1.Visible = true;
            guna2DataGridView2.Visible = false;
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable datasource1 = connectionn0.GetDataEdit(2);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
  

                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";

                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource1;
            }
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable datasource2 = connectionn1.GetDataEdit(2);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();


                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource2;
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable datasource3 = connectionn2.GetDataEdit(2);
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
     

                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên chuyến tàu", DataPropertyName = "TenChuyenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "Thoigianchay" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đi", DataPropertyName = "TenGaDi" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên ga đến", DataPropertyName = "TenGaDen" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số lượng vé", DataPropertyName = "SoVeToiDa" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource3;
            }



        }
        public void loadInfoGaTau()
        {
            guna2DataGridView1.Visible = true;
            guna2DataGridView2.Visible = false;
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable datasource = connectionn0.GetDataGaTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
               
                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Ga tàu", DataPropertyName = "TenGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Ga Tàu", DataPropertyName = "TTGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Ga Tàu", DataPropertyName = "TinhTrangGa" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable datasource = connectionn1.GetDataGaTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
      
                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Ga tàu", DataPropertyName = "TenGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Ga Tàu", DataPropertyName = "TTGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Ga Tàu", DataPropertyName = "TinhTrangGa" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable datasource = connectionn2.GetDataGaTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
             
                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Ga tàu", DataPropertyName = "TenGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Ga Tàu", DataPropertyName = "TTGaTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Ga Tàu", DataPropertyName = "TinhTrangGa" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource;
            }



        }

        public void loadInfoTau()
        {
            guna2DataGridView1.Visible = true;
            guna2DataGridView2.Visible = false;
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable datasource = connectionn0.GetDataTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
      
                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Tàu", DataPropertyName = "TTTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Tàu", DataPropertyName = "TT" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable datasource = connectionn1.GetDataTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
           
                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Tàu", DataPropertyName = "TTTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Tàu", DataPropertyName = "TT" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource;
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable datasource = connectionn2.GetDataTau();
                DataGridViewButtonColumn Edit = new DataGridViewButtonColumn();
       
                DataGridViewButtonColumn Accept = new DataGridViewButtonColumn();
                Accept.DataPropertyName = "Accept";
                Accept.UseColumnTextForButtonValue = true;
                Accept.Text = "Cập Nhật";
                DataGridViewButtonColumn Accept2 = new DataGridViewButtonColumn();
                Accept2.DataPropertyName = "Accept2";
                Accept2.UseColumnTextForButtonValue = true;
                Accept2.Text = "Xoá";
                this.guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Columns.Clear();
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", Width = 500 });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên tàu", DataPropertyName = "TenTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thông tin Tàu", DataPropertyName = "TTTau" });
                this.guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình Trạng Tàu", DataPropertyName = "TT" });
                this.guna2DataGridView1.Columns.Add(Accept);
                this.guna2DataGridView1.Columns.Add(Accept2);
                guna2DataGridView1.DataSource = datasource;
            }


        }


        CheckBox headerCheckBox = new CheckBox();
        public void loadInfoHD()
        {
            guna2DataGridView2.Columns.Clear();
         

            guna2DataGridView1.Visible = false;
            guna2DataGridView2.Visible = true;

      
            if (stre == "Đà Nẵng")
            {
                string ConnectionString = "Data Source=ADMIN;Initial Catalog=Datvetauhoa0;User ID=sa;Password=123456";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHD, TenCT, SoLuongve, Total, TinhTrangHoadon from HoaDon", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                guna2DataGridView2.DataSource = dt;
                              
                            }
                        }
                    }
                }
            }
            else if (stre == "Hồ Chí Minh")
            {
                string ConnectionString = "Data Source=ADMIN\\MSSQLSERVER01;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHD, TenCT, SoLuongve, Total, TinhTrangHoadon from HoaDon", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                guna2DataGridView2.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else if (stre == "Hà Nội")
            {
                string ConnectionString = "Data Source=ADMIN\\MSSQLSERVER02;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHD, TenCT, SoLuongve, Total, TinhTrangHoadon from HoaDon", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);

                                guna2DataGridView2.DataSource = dt;
                            }
                        }
                    }
                }
            }
            
            Rectangle headerCellLocation = this.guna2DataGridView2.GetCellDisplayRectangle(0, -1, true);

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCellLocation.X = headerCellLocation.Location.X + 61;
            headerCellLocation.Y = headerCellLocation.Location.Y + (headerCellLocation.Height / 4);
            headerCheckBox.BackColor = Color.FromArgb(110, 0, 239);

            headerCheckBox.Location = headerCellLocation.Location;
            headerCheckBox.Size = new Size(14, 14);
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            guna2DataGridView2.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            guna2DataGridView2.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            guna2DataGridView2.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }
        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            if (stre == "Đà Nẵng")
            {
                SqlConnection conn = new SqlConnection("Data Source=ADMIN;Initial Catalog=Datvetauhoa0;User ID=sa;Password=123456");

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        SqlDataAdapter abc = new SqlDataAdapter("DELETE FROM HoaDon WHERE MaHD='" + row.Cells[1].Value.ToString() + "'", conn);
                        DataTable bc = new DataTable();
                        abc.Fill(bc);
                     
                    }
           
                }
                   MessageBox.Show("Xoá thành công");
                        loadInfoHD();
            }

            else if (stre == "Hồ Chí Minh")
            {
                SqlConnection conn = new SqlConnection("Data Source=ADMIN\\MSSQLSERVER01;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456");

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        SqlDataAdapter abc = new SqlDataAdapter("DELETE FROM HoaDon WHERE MaHD='" + row.Cells[1].Value.ToString() + "'", conn);
                        DataTable bc = new DataTable();
                        abc.Fill(bc);

                    }

                }
                MessageBox.Show("Xoá thành công");
                loadInfoHD();

            }
            else if (stre == "Hà Nội")
            {
                SqlConnection conn = new SqlConnection("Data Source=ADMIN\\MSSQLSERVER02;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456");

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        SqlDataAdapter abc = new SqlDataAdapter("DELETE FROM HoaDon WHERE MaHD='" + row.Cells[1].Value.ToString() + "'", conn);
                        DataTable bc = new DataTable();
                        abc.Fill(bc);

                    }

                }
                MessageBox.Show("Xoá thành công");
                loadInfoHD();

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            if (stre == "Đà Nẵng")
            {

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        string mahd = row.Cells[1].Value.ToString();
                        DBconnection0 connectionn0 = new DBconnection0();
                        connectionn0.capnhattrangthaihoadon(mahd,keytrangthai);

                    }

                }
                MessageBox.Show("Cập nhật thành công");
                loadInfoHD();
            }

            else if (stre == "Hồ Chí Minh")
            {

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        string mahd = row.Cells[1].Value.ToString();
                        DBconnection1 connectionn1 = new DBconnection1();
                        connectionn1.capnhattrangthaihoadon(mahd, keytrangthai);

                    }

                }
                MessageBox.Show("Cập nhật thành công");
                loadInfoHD();

            }
            else if (stre == "Hà Nội")
            {
                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        string mahd = row.Cells[1].Value.ToString();
                        DBconnection2 connectionn2 = new DBconnection2();
                        connectionn2.capnhattrangthaihoadon(mahd, keytrangthai);

                    }

                }
                MessageBox.Show("Cập nhật thành công");
                loadInfoHD();

            }
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            guna2DataGridView2.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                if (row.Cells[1].Value != DBNull.Value)
                {
                  DataGridViewCheckBoxCell checkBox = (row.Cells[0] as DataGridViewCheckBoxCell);
                    checkBox.Value = headerCheckBox.Checked;
                }
           
            }
        }

        public void LOcInfoHD()
        {
            string keyloc = guna2TextBox1.Text;
            guna2DataGridView2.Columns.Clear();


            guna2DataGridView1.Visible = false;
            guna2DataGridView2.Visible = true;


            if (stre == "Đà Nẵng")
            {
                string ConnectionString = "Data Source=ADMIN;Initial Catalog=Datvetauhoa0;User ID=sa;Password=123456";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHD, TenCT, SoLuongve, Total, TinhTrangHoadon from HoaDon WHERE[TenCT] LIKE '%" + keyloc + "%'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                guna2DataGridView2.DataSource = dt;

                            }
                        }
                    }
                }
            }
            else if (stre == "Hồ Chí Minh")
            {
                string ConnectionString = "Data Source=ADMIN;Initial Catalog=Datvetauhoa1;User ID=sa;Password=123456";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHD, TenCT, SoLuongve, Total, TinhTrangHoadon from HoaDon WHERE[TenCT] LIKE '%" + keyloc + "%'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                guna2DataGridView2.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else if (stre == "Hà Nội")
            {
                string ConnectionString = "Data Source=ADMIN;Initial Catalog=Datvetauhoa2;User ID=sa;Password=123456";
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHD, TenCT, SoLuongve, Total, TinhTrangHoadon from HoaDon WHERE[TenCT] LIKE '%" + keyloc + "%'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);

                                guna2DataGridView2.DataSource = dt;
                            }
                        }
                    }
                }
            }



            Rectangle headerCellLocation = this.guna2DataGridView2.GetCellDisplayRectangle(0, -1, true);

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCellLocation.X = headerCellLocation.Location.X + 61;
            headerCellLocation.Y = headerCellLocation.Location.Y + (headerCellLocation.Height / 4);
            headerCheckBox.BackColor = Color.FromArgb(110, 0, 239);

            headerCheckBox.Location = headerCellLocation.Location;
            headerCheckBox.Size = new Size(14, 14);
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            guna2DataGridView2.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            guna2DataGridView2.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            guna2DataGridView2.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

      

      

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            stre = FmDoashboard.stree2;

            if(keydata == "Chuyến Tàu")
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

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            timer1.Start();

            keydata = guna2ComboBox1.Text;
            if (keydata == "Chuyến Tàu")
            {
                loadInfoChuyentau();
                guna2TextBox1.Visible = false;
                guna2Button2.Visible = false;
                guna2Button1.Visible = false;
                guna2ComboBox2.Visible = false;
                label3.Visible = false;
            }
            else if (keydata == "Ga Tàu")
            {
  
                loadInfoGaTau();
                guna2TextBox1.Visible = false;
                guna2Button2.Visible = false;
                guna2Button1.Visible = false;
                guna2ComboBox2.Visible = false;
                label3.Visible = false;
            }
            else if (keydata == "Tàu")
            {
                loadInfoTau();
                guna2TextBox1.Visible = false;
                guna2Button2.Visible = false;
                guna2Button1.Visible = false;
                guna2ComboBox2.Visible = false;
                label3.Visible = false;
            }
            else if (keydata == "Hoá Đơn")
            {
                loadInfoHD();
                guna2TextBox1.Visible = true;
                guna2Button2.Visible = true;
                guna2Button1.Visible = true;
                guna2ComboBox2.Visible = true;
                label3.Visible = true;
            }
        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
       
            keydata = guna2ComboBox1.Text;
            if (keydata == "Chuyến Tàu")
            {
                int Mahd = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (e.ColumnIndex == 9)
                {
                    deletedata_CT(Mahd);
                }
                if (e.ColumnIndex == 8)
                {
                    Update_CT ks = new Update_CT(Mahd);
                    ks.Show();
                }
            }
            else if (keydata == "Ga Tàu")
            {
                int Mahd = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string desc = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string sta = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (e.ColumnIndex == 5)
                {
                    deletedata_GT(Mahd);
                }
                if (e.ColumnIndex == 4)
                {

                    Update_GT ks = new Update_GT(Mahd, name, desc, sta);
                    ks.Show();
                }
            }
            else if (keydata == "Tàu")
            {
                int Mahd = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string desc = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string sta = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (e.ColumnIndex == 5)
                {
                    deletedata_T(Mahd);
                }
                if (e.ColumnIndex == 4)
                {
                    Update_T ks = new Update_T(Mahd, name, desc, sta);
                    ks.Show();

                }
            }
        }


        public void deletedata_CT(int data)
        {
            if (stre == "Đà Nẵng")
            {
              DBconnection0 connectionn0 = new DBconnection0();
              bool kaa =  connectionn0.Deletedata_CT(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }
            }
                        
               
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                bool kaa = connectionn1.Deletedata_CT(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }

            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                bool kaa = connectionn2.Deletedata_CT(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }

            }

          }


        public void deletedata_GT(int data)
        {
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                bool kaa = connectionn0.Deletedata_GT(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }
            }


            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                bool kaa = connectionn1.Deletedata_GT(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }

            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                bool kaa = connectionn2.Deletedata_GT(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }

            }

        }

        public void deletedata_T(int data)
        {
            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                bool kaa = connectionn0.Deletedata_T(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }
            }


            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                bool kaa = connectionn1.Deletedata_T(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }

            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                bool kaa = connectionn2.Deletedata_T(data);
                if (kaa == true)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thất bại");
                }

            }

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
      
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            LOcInfoHD();
        }

        private void guna2DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex==5 & e.Value != null)
            {
                string key = e.Value.ToString();
                if (key.Equals("New"))
                {
                    e.CellStyle.BackColor = Color.GreenYellow;

                }else if (key.Equals("Went"))
                {
                    e.CellStyle.BackColor = Color.Red;

                }
                else if (key.Equals("Walking"))
                {
                    e.CellStyle.BackColor = Color.Yellow;

                }
            }
        }

     

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            keytrangthai = guna2ComboBox2.Text;
        }
    }
}
