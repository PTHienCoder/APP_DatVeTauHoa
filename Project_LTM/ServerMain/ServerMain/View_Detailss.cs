using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Command_Main;
namespace ServerMain
{

    public partial class View_Detailss : Form
    {
        public SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adater;
        private DataTable table;
        private string key = SerializeHelpers.GetKey();
        private int MaDH;
        public SocketServer Server { get; set; }
        public View_Detailss(int mahd)
        {
            this.MaDH = mahd;
            InitializeComponent();
           
        }
        void socketServer_OnDataReceived(object sender, ReceivedDataEventArgs e)
        { }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void View_Detailss_Load(object sender, EventArgs e)
        {

             string strConnectionString = "Data Source=ADMIN;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
           
            string sql = "select Soluongve,LoaiGhe,NgayDat,ThoigianChay,MaHD,total,Gaden,Gadi,TinhTrangHoaDon,TenDayDu,TenDangNhap,SoDienThoai,Email,DiaChi from HoaDon dv, NguoiDung nd where nd.ID=dv.MaKH and dv.MaHD ='" + MaDH + "'";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            SqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
              
                label24.Text = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, reader["TenDayDu"].ToString(), true);
                label26.Text = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, reader["DiaChi"].ToString(), true);
                label28.Text = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, reader["Email"].ToString(), true);
                label29.Text = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, reader["TenDangNhap"].ToString(), true);
                label27.Text = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, reader["SoDienThoai"].ToString(), true);
      

                label17.Text = reader["Gadi"].ToString();
                label18.Text = reader["Gaden"].ToString();
                label19.Text = reader["TinhTrangHoaDon"].ToString();
                label30.Text = reader["LoaiGhe"].ToString();
                label23.Text = reader["total"].ToString();
                label15.Text = reader["MaHD"].ToString();
                label22.Text = reader["Soluongve"].ToString();
                label20.Text = reader["ThoigianChay"].ToString();
                label21.Text = reader["NgayDat"].ToString();



            }
      
  
           // command.Parameters.AddWithValue("TenDayDu", label24.Text);
        }
    }
}
