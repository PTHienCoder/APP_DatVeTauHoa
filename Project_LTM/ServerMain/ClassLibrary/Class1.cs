using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Command_Main;
namespace ClassLibrary
{
    public class Class1
    {
        public SqlConnection connection;
        public SqlConnection connection0;
        public SqlConnection connection1;
        public SqlConnection connection2;
        private SqlCommand command;
        private SqlDataAdapter adater;
        private DataTable table;
        private string key = SerializeHelpers.GetKey();


        // public string ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=AnNinhMang;User ID=sa; Password=123456";
        // private string connectstring = "server=.; database=AnNinhMang; integrated security = true;";

        static string strConnectionString = "Data Source=ADMIN;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
        static string strConnectionString0 = "Data Source=ADMIN;Initial Catalog=Datvetauhoa0;User ID=sa;Password=123456";
        static string strConnectionString1 = "Data Source=ADMIN\\MSSQLSERVER01;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
        static string strConnectionString2 = "Data Source=ADMIN\\MSSQLSERVER02;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
        public void OpenConnection()
        {
            connection = new SqlConnection(strConnectionString);

            connection.Open();

        }
        public void OpenConnection0()
        {
            connection0 = new SqlConnection(strConnectionString0);

            connection0.Open();

        }
        public void OpenConnection1()
        {
            connection1 = new SqlConnection(strConnectionString1);

            connection1.Open();

        }
        public void OpenConnection2()
        {
            connection2 = new SqlConnection(strConnectionString2);

            connection2.Open();

        }
        public void CloseConnection()
        {

            connection.Close();
        }
        public void CloseConnection2()
        {

            connection2.Close();
        }
        public void CloseConnection0()
        {

            connection0.Close();
        }
        public void CloseConnection1()
        {

            connection1.Close();
        }


        public DataTable ExecuteCommandText(string cmdText)
        {
            DataTable data = null;

            OpenConnection();
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmdText;
            command.Connection = connection;

            adater = new SqlDataAdapter(command);

            data = new DataTable();
            adater.Fill(data);
            CloseConnection();
            return data;
        }
        public DataTable ExecuteCommandText0(string cmdText)
        {
            DataTable data = null;
            OpenConnection0();
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmdText;
            command.Connection = connection0;

            adater = new SqlDataAdapter(command);

            data = new DataTable();
            adater.Fill(data);
            CloseConnection0();
            return data;
        }
        public DataTable ExecuteCommandText1(string cmdText)
        {
            DataTable data = null;

            OpenConnection1();
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmdText;
            command.Connection = connection1;

            adater = new SqlDataAdapter(command);

            data = new DataTable();
            adater.Fill(data);
            CloseConnection1();
            return data;
        }
        public DataTable ExecuteCommandText2(string cmdText)
        {
            DataTable data = null;

            OpenConnection2();
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmdText;
            command.Connection = connection2;

            adater = new SqlDataAdapter(command);

            data = new DataTable();
            adater.Fill(data);
            CloseConnection2();
            return data;
        }

        public DataSet GetData(string cmdText)
        {


            OpenConnection();
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = cmdText;
            command.Connection = connection;

            adater = new SqlDataAdapter(command);

            DataSet data1 = new DataSet();
            adater.Fill(data1);
            CloseConnection();
            return data1;
        }

        // đăng nhập admindbo.Tau

        public bool dangkykhachhang(string user, string pass, string name, string diachi, string phone, string email)
        {


            string User = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, user, true);
            string Pass = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, pass, true);
            string Name = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, name, true);
            string Diachi = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, diachi, true);
            string Phone = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, phone, true);
            string Email = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, email, true);

            int sodu = 5000000;
            string Sodu = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, Convert.ToString(sodu), true);
            string LoaiTK = "KHT";





            string sql = " Insert Into NguoiDung (TenDangNhap,MatKhau,DiaChi,SoDienThoai,LoaiTaiKhoan,SoDu,TenDayDu,Email) values(@user,@pass,@adress,@phone,@loaitk,@sodu,@ten,@email)";


            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;

            command.Parameters.AddWithValue("@user", User);
            command.Parameters.AddWithValue("@pass", Pass);
            command.Parameters.AddWithValue("@adress", Diachi);
            command.Parameters.AddWithValue("@phone", Phone);
            command.Parameters.AddWithValue("@loaitk", LoaiTK);
            command.Parameters.AddWithValue("@sodu", Sodu);
            command.Parameters.AddWithValue("@ten", Name);
            command.Parameters.AddWithValue("@email", Email);





            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;

        }
        public DataTable GetGa()
        {

            string sql = "select id,TenGaTau from GaTau";
            DataTable data = ExecuteCommandText(sql);


            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("id", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaTau", typeof(string)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["id"] = data.Rows[i]["id"].ToString();
                NewRow["TenGatau"] = data.Rows[i]["TenGaTau"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable GetGa0()
        {

            string sql = "select id,TenGaTau from GaTau";
            DataTable data = ExecuteCommandText0(sql);


            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("id", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaTau", typeof(string)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["id"] = data.Rows[i]["id"].ToString();
                NewRow["TenGatau"] = data.Rows[i]["TenGaTau"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable GetGa1()
        {

            string sql = "select id,TenGaTau from GaTau";
            DataTable data = ExecuteCommandText1(sql);


            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("id", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaTau", typeof(string)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["id"] = data.Rows[i]["id"].ToString();
                NewRow["TenGatau"] = data.Rows[i]["TenGaTau"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable GetGa2()
        {

            string sql = "select id,TenGaTau from GaTau";
            DataTable data = ExecuteCommandText2(sql);


            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("id", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaTau", typeof(string)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["id"] = data.Rows[i]["id"].ToString();
                NewRow["TenGatau"] = data.Rows[i]["TenGaTau"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable SendInfo()
        {
            OpenConnection0();
            string sql = "SELECT * from ChuyenTau";
            SqlCommand command = new SqlCommand(sql, connection0);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable SendInfoSearch0(string key)
        {
            OpenConnection0();

            string sql = "SELECT * from ChuyenTau WHERE[TenChuyenTau] LIKE '%" + key + "%' OR [GaDi] LIKE '%" + key + "%' OR [GaDen] LIKE '%" + key + "%'";

            SqlCommand command = new SqlCommand(sql, connection0);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable SendInfoSearch1(string key)
        {
            OpenConnection1();

            string sql = "SELECT * from ChuyenTau WHERE[TenChuyenTau] LIKE '%" + key + "%' OR [GaDi] LIKE '%" + key + "%' OR [GaDen] LIKE '%" + key + "%'";

            SqlCommand command = new SqlCommand(sql, connection1);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable SendInfoSearch2(string key)
        {
            OpenConnection2();

            string sql = "SELECT * from ChuyenTau WHERE[TenChuyenTau] LIKE '%" + key + "%' OR [GaDi] LIKE '%" + key + "%' OR [GaDen] LIKE '%" + key + "%'";

            SqlCommand command = new SqlCommand(sql, connection2);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
