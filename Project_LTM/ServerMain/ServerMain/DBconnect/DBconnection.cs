using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ServerMain.DBconnect
{
    class DBconnection
    {
        public SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adater;
        private DataTable table;
        private string key = SerializeHelpers.GetKey();


        // public string ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=AnNinhMang;User ID=sa; Password=123456";
        // private string connectstring = "server=.; database=AnNinhMang; integrated security = true;";
        static string strConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Datvetauhoa;Persist Security Info=True;User ID=sa;Password=123456";
        public void OpenConnection()
        {
            connection = new SqlConnection(strConnectionString);

            connection.Open();

        }
        public void CloseConnection()
        {

            connection.Close();
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
        public bool ValidateLoginServer(string user, string pass)
        {

            string s = user.Trim();
            while (s.IndexOf("  ") >= 0)    //tim trong chuoi vi tri co 2 khoang trong tro len      
                s = s.Replace("  ", " ");   //sau do thay the bang 1 khoang trong            

           // string Tendangnhap = SVCommom.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, user, true);
         //   string Matkhau = SVCommom.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, pass, true);

            string query = "SELECT Count(*) as DEM FROM AD_User WHERE User_ad='" + user + "' AND Pass_ad='" + pass + "'";

            DataTable data = ExecuteCommandText(query);
            if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                return true;
            else
                return false;
        }




        public bool ThemChuyenTau(string tenchuyentau, string ngaykhoihanh, string thoigiandi, string gaden, string gadi, string matau, string sovetoida, string soluongvecho1nguoi)
        {
         //   string Tenchuyentau = SVCommom.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, tenchuyentau, true);
           // string Ngaykhoihanh = SVCommom.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, ngaykhoihanh, true);
           // string Thoigiandi = SVCommom.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, thoigiandi, true);
           // string Soluongvecho1nguoi = SVCommom.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, soluongvecho1nguoi, true);
           // string soluongvetoida = SVCommom.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, Convert.ToString(sovetoida), true);
            string sql = " Insert Into Chuyentau (Tenchuyentau,ThoigianChay,GaDi,GaDen,SoVeToiDa,MaTau,NgayDi,SoLuongVe) values(@Tenchuyentau,@Thoigiandi,@gadi,@gaden,@soluongvetoida,@matau,@Ngaykhoihanh,@Soluongvecho1nguoi)";


            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@Soluongvecho1nguoi", soluongvecho1nguoi);

            command.Parameters.AddWithValue("@Tenchuyentau", tenchuyentau);
            command.Parameters.AddWithValue("@Ngaykhoihanh", ngaykhoihanh);


            command.Parameters.AddWithValue("@Thoigiandi", thoigiandi);
            command.Parameters.AddWithValue("@soluongvetoida", sovetoida);

            command.Parameters.AddWithValue("@gaden", gaden);
            command.Parameters.AddWithValue("@gadi", gadi);

            command.Parameters.AddWithValue("@matau", matau);

        
            int rows = command.ExecuteNonQuery();
       
            if (rows > 0)

                return true;

            else
                return false;

        }
        public DataTable GetDataEdit(int flag)
        {
            if (flag == 1 )
            {
                string sql = "SELECT * from Chuyentau";
                DataTable data = ExecuteCommandText(sql);

                DataTable DataTable_Decrypt = new DataTable();
                DataTable_Decrypt.Columns.Add(new DataColumn("Machuyentau", typeof(int)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenChuyenTau", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("Thoigianchay", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("NgayDi", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDi", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDen", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("SoVeToiDa", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenTau", typeof(string)));
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow NewRow = DataTable_Decrypt.NewRow();
                    NewRow["Machuyentau"] = data.Rows[i]["Machuyentau"].ToString();
                    NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                    NewRow["Thoigianchay"] = data.Rows[i]["Thoigianchay"].ToString();
                    NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                    NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                    NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                    NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                    NewRow["TenTau"] = data.Rows[i]["MaTau"].ToString();

                    DataTable_Decrypt.Rows.Add(NewRow);
                }

                return DataTable_Decrypt;
            }
            else if (flag == 2)
            {
                string sql = "SELECT * from Chuyentau";
                DataTable data = ExecuteCommandText(sql);

                DataTable DataTable_Decrypt = new DataTable();
                DataTable_Decrypt.Columns.Add(new DataColumn("STT", typeof(int)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenChuyenTau", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("Thoigianchay", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("NgayDi", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDi", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDen", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("SoVeToiDa", typeof(string)));
                DataTable_Decrypt.Columns.Add(new DataColumn("TenTau", typeof(string)));
                int a = 0;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    a++;
                    DataRow NewRow = DataTable_Decrypt.NewRow();
                    NewRow["STT"] = a.ToString();
                    NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                    NewRow["Thoigianchay"] = data.Rows[i]["Thoigianchay"].ToString();
                    NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                    NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                    NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                    NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                    NewRow["TenTau"] = data.Rows[i]["MaTau"].ToString();

                    DataTable_Decrypt.Rows.Add(NewRow);
                }

                return DataTable_Decrypt;
            }
            else {
                string sql = "SELECT * from Chuyentau";
                DataTable data = ExecuteCommandText(sql);

                return data;
            }


            
        }





     }
}


   

