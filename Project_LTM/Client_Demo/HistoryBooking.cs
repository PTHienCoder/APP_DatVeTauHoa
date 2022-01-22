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
using Guna.UI2.WinForms;

namespace Client_Demo
{

    //public delegate void DlgInitGrid(object datasource);
    public partial class HistoryBooking : Form
    {
        string name;
        int id;
        string keysts = "New";
        public SocketClient Client { get; set; }
        public HistoryBooking(string Myname, int ID)
        {
            this.name = Myname;
            this.id = ID;
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

        void Client_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {
            Command_Main.Message messageResponse = Command_Main.Message.Parse(e.Data);

            switch (messageResponse.Command)
            {
                case Command_Main.Command.HictoryVT:

                    SenReponHistory sendInfoResponse = (SenReponHistory)SerializeHelpers.DeserializeData(messageResponse.DataByte);
                    DataTable Data1 = new DataTable();
                    Data1.Columns.Add("MaHD");
                    Data1.Columns.Add("TenChuyenTau");
                    Data1.Columns.Add("NgayDi");
                    Data1.Columns.Add("ThoiGianChay");
                    Data1.Columns.Add("TenGaDi");
                    Data1.Columns.Add("TenGaDen");
                    Data1.Columns.Add("SoLuong");
                    Data1.Columns.Add("ToTal");
                    Data1.Columns.Add("Status");
                   
                    for (int i = 0; i < sendInfoResponse.Items.Length; i++)
                    {
                        
                           
                        if (sendInfoResponse.Items[i].TinhTrang .Equals(keysts))
                        {
                            DataRow newRow = Data1.NewRow();
                            newRow["MaHD"] = sendInfoResponse.Items[i].maHD;
                            newRow["TenChuyenTau"] = sendInfoResponse.Items[i].TenChuyentau;
                            newRow["NgayDi"] = sendInfoResponse.Items[i].Ngaydi;
                            newRow["ThoiGianChay"] = sendInfoResponse.Items[i].ThoiGianChay;
                            newRow["TenGaDi"] = sendInfoResponse.Items[i].GaDi;
                            newRow["TenGaDen"] = sendInfoResponse.Items[i].GaDen;
                            newRow["SoLuong"] = sendInfoResponse.Items[i].Soluongve;
                            newRow["Total"] = sendInfoResponse.Items[i].Total;
                            newRow["Status"] = sendInfoResponse.Items[i].TinhTrang;
                            Data1.Rows.Add(newRow);
                        }
                      
                     
                    }
                    //  Data1.AcceptChanges();
                    InitializeGrid(Data1);
                    break;
            }

        }
        private void InitializeGrid(object datasource)
        {

            DataGridViewButtonColumn sell = new DataGridViewButtonColumn();
            sell.DataPropertyName = "Sell";
            sell.UseColumnTextForButtonValue = true;
            if (keysts.Equals("New"))
            {
                sell.Text = "Huỷ Vé";
            }
            else if (keysts.Equals("Went"))
            {
                sell.Text = "Xoá";
            }
        

            if (this.DGVInfo.InvokeRequired)
            {
                this.DGVInfo.Invoke(new DlgInitGrid(this.InitializeGrid), new object[] { datasource });
                return;
            }

            this.DGVInfo.AutoGenerateColumns = false;
            this.DGVInfo.Columns.Clear();
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Mã HĐ", DataPropertyName = "MaHD" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên Chuyến Tàu", DataPropertyName = "TenChuyenTau" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ngày đi", DataPropertyName = "NgayDi" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian khởi hành", DataPropertyName = "ThoiGianChay" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ga Đi", DataPropertyName = "TenGaDi" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ga Đến", DataPropertyName = "TenGaDen" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Số Lượng", DataPropertyName = "SoLuong" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tổng Tiền", DataPropertyName = "Total" });
            this.DGVInfo.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Trạng Thái", DataPropertyName = "Status" });
            if (keysts.Equals("New") || keysts.Equals("Went"))
            {
                this.DGVInfo.Columns.Add(sell);
            }
   

          //  this.DGVInfo.DataSource = Data1;
            BindingSource source = new BindingSource();
            source.DataSource = datasource;
           
            this.DGVInfo.DataSource = datasource;

        }
        private void DGVInfoticket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahd = Convert.ToString(DGVInfo.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (e.ColumnIndex == 9)
            {
                Modal_Del_CT fr = new Modal_Del_CT(mahd, name, id);
                fr.SetClient(this.Client);
                fr.Show();
            }
            else
            {

            }
        }
        private void HistoryBooking_Load(object sender, EventArgs e)
        {
            label9.Text = " Lịch sử đặt vé tàu của " + name;

            SendRequestHistoty res = new SendRequestHistoty(id);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.HictoryVT, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }
        public void loaddata()
        {
        
        }
        private void label9_Click(object sender, EventArgs e)
        {
     
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keysts = Convert.ToString(guna2ComboBox1.Text.ToString());

            SendRequestHistoty res = new SendRequestHistoty(id);
            Command_Main.Message ms = new Command_Main.Message(Command_Main.Command.HictoryVT, SerializeHelpers.SerializeData(res));
            this.Client.Send(ms.ToMessage());
        }

        private void guna2ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
         
         
        }

        private void DGVInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8 & e.Value != null)
            {
                string key = e.Value.ToString();
                if (key.Equals("New"))
                {
                    e.CellStyle.BackColor = Color.GreenYellow;

                }
                else if (key.Equals("Went"))
                {
                    e.CellStyle.BackColor = Color.Red;

                }
                else if (key.Equals("Walking"))
                {
                    e.CellStyle.BackColor = Color.Yellow;

                }
            }
        }
    }
}
