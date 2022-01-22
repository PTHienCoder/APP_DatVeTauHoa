using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Command_Main;

namespace ServerMain
{
    class DBconnection2
    {
        string keya;
        public SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adater;
        private DataTable table;
        private string key = SerializeHelpers.GetKey();


        // public string ConnectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=AnNinhMang;User ID=sa; Password=123456";
        // private string connectstring = "server=.; database=AnNinhMang; integrated security = true;";
        static string strConnectionString = "Data Source=ADMIN\\MSSQLSERVER02;Initial Catalog=Datvetauhoa;User ID=sa;Password=123456";
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

            //   string Tendangnhap = Command.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, user, false);
            // string Matkhau = Command.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, pass, true);

            string query = "SELECT Count(*) as DEM FROM AD_User WHERE User_ad ='" + user + "' AND Pass_ad='" + pass + "'";

            DataTable data = ExecuteCommandText(query);
            if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                return true;
            else
                return false;
        }


        public bool ValidateLogin(string user, string pass)
        {
            try
            {
                string s = user.Trim();
                while (s.IndexOf("  ") >= 0)    //tim trong chuoi vi tri co 2 khoang trong tro len      
                    s = s.Replace("  ", " ");   //sau do thay the bang 1 khoang trong            



                string Tendangnhap = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, user, true);
                string Matkhau = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, pass, true);

                string query = "SELECT Count(*) as DEM FROM NguoiDung WHERE TenDangNhap='" + Tendangnhap + "' AND MatKhau='" + Matkhau + "'";

                DataTable data = ExecuteCommandText(query);
                if (Convert.ToInt32(data.Rows[0]["DEM"].ToString()) > 0)

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }

        public DataTable GetGa()
        {
            OpenConnection();
            string sql = "select id,TenGaTau from GaTau";

            //string sql = "SELECT * from ChuyenTau";
            SqlCommand command = new SqlCommand(sql, connection);
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

        public DataTable GetTau()
        {
            string sql = "select id,TenTau from Tau";
            DataTable data = ExecuteCommandText(sql);


            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("id", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenTau", typeof(string)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["id"] = data.Rows[i]["id"].ToString();

                NewRow["TenTau"] = data.Rows[i]["TenTau"].ToString();



                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }

        public DataTable SendInfoUser(string tendangnhap, string matkhau)
        {
            string s = tendangnhap.Trim();
            while (s.IndexOf("  ") >= 0)    //tim trong chuoi vi tri co 2 khoang trong tro len      
                s = s.Replace("  ", " ");
            string Tendangnhap = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, s, true);
            string Matkhau = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, matkhau, true);

            string sql = "SELECT  *  from nguoidung where tendangnhap ='" + Tendangnhap + "' and matkhau ='" + Matkhau + "' ";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("TenDangNhap", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("MatKhau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("DiaChi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("SoDienThoai", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("SoDu", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenDayDu", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Email", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Id", typeof(string)));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["Id"] = data.Rows[i]["Id"].ToString();
                NewRow["TenDangNhap"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["TenDangNhap"].ToString(), true);
                NewRow["MatKhau"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["MatKhau"].ToString(), true);
                NewRow["DiaChi"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["DiaChi"].ToString(), true);

                NewRow["SoDienThoai"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["SoDienThoai"].ToString(), true);
                NewRow["SoDu"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["SoDu"].ToString(), true);

                NewRow["TenDayDu"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["TenDayDu"].ToString(), true);
                NewRow["Email"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Email"].ToString(), true);



                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }


        public DataTable GetIDNguoidung(string nguoidung)
        {
            string s = nguoidung.Trim();
            while (s.IndexOf("  ") >= 0)    //tim trong chuoi vi tri co 2 khoang trong tro len      
                s = s.Replace("  ", " ");
            string Nguoidung = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, s, true);
            string sql = "select Id from Nguoidung where TenDangNhap ='" + Nguoidung + "'";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("Id", typeof(int)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();


                NewRow["Id"] = Convert.ToInt32(data.Rows[i]["Id"].ToString());


                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
            // return data;

        }


        public bool ThemChuyenTau(string tenchuyentau, string ngaykhoihanh, string thoigiandi, string gaden, string gadi, string matau, string sovetoida, string soluongvecho1nguoi, int giave, string CN)
        {


            string CNhanh = "";
            if (CN.Equals("Đà Nẵng"))
            {
                CNhanh = "CN0";
            }
            else if (CN.Equals("Hồ Chí Minh"))
            {
                CNhanh = "CN1";
            }
            else if (CN.Equals("Hà Nội"))
            {
                CNhanh = "CN2";
            }
            string Tenchuyentau = tenchuyentau;
            string Ngaykhoihanh = ngaykhoihanh;
            string Thoigiandi = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, thoigiandi, true);
            string Soluongvecho1nguoi = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, soluongvecho1nguoi, true);
            string soluongvetoida = Convert.ToString(sovetoida);
            string sql = " Insert Into Chuyentau (Tenchuyentau,ThoigianChay,GaDi,GaDen,SoVeToiDa,MaTau,NgayDi,SoLuongVe,GiaVe,MaCN) values(@Tenchuyentau,@Thoigiandi,@gadi,@gaden,@soluongvetoida,@matau,@Ngaykhoihanh,@Soluongvecho1nguoi,@giave,@macn)";


            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@Soluongvecho1nguoi", Soluongvecho1nguoi);

            command.Parameters.AddWithValue("@Tenchuyentau", Tenchuyentau);
            command.Parameters.AddWithValue("@Ngaykhoihanh", Ngaykhoihanh);


            command.Parameters.AddWithValue("@Thoigiandi", Thoigiandi);
            command.Parameters.AddWithValue("@soluongvetoida", soluongvetoida);

            command.Parameters.AddWithValue("@gaden", gaden);
            command.Parameters.AddWithValue("@gadi", gadi);

            command.Parameters.AddWithValue("@matau", matau);
            command.Parameters.AddWithValue("@giave", giave);
            command.Parameters.AddWithValue("@macn", CNhanh);


            int rows = command.ExecuteNonQuery();

            if (rows > 0)

                return true;

            else
                return false;

        }
        public bool ThemGaTau(string tengatau, string thongtin, string chinhanh, string tinhtrang)
        {

            string sql = " Insert Into GaTau (TenGaTau,TTGaTau,TinhTrangGa,MaCN) values(@TenGaTau,@TTGaTau,@TinhTrangGa,@CNGaTau)";


            if (chinhanh == "Đà Nẵng")
            {
                keya = "CN0";
            }
            else if (chinhanh == "Hà Nội")
            {
                keya = "CN2";
            }
            else if (chinhanh == "TP.Hồ Chí Minh")
            {
                keya = "CN1";
            }

            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@TenGaTau", tengatau);
            command.Parameters.AddWithValue("@TTGaTau", thongtin);
            command.Parameters.AddWithValue("@CNGaTau", Convert.ToString(keya));
            command.Parameters.AddWithValue("@TinhTrangGa", tinhtrang);


            int rows = command.ExecuteNonQuery();

            if (rows > 0)

                return true;

            else
                return false;

        }
        public bool ThemTau(string tentau, string thongtin, int gatau, string tinhtrang)
        {

            string sql = " Insert Into Tau (TenTau,TTTau,TT,IDgatau) values(@TenTau,@TTTau,@TT,@GaTau)";



            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;
            command.Parameters.AddWithValue("@TenTau", tentau);
            command.Parameters.AddWithValue("@TTTau", thongtin);

            command.Parameters.AddWithValue("@GaTau", gatau);
            command.Parameters.AddWithValue("@TT", tinhtrang);


            int rows = command.ExecuteNonQuery();

            if (rows > 0)

                return true;

            else
                return false;

        }
        public DataTable GetDataEdit(int flag)
        {
            if (flag == 1)
            {
                string sql = "SELECT * from ChuyenTau";
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
                DataTable_Decrypt.Columns.Add(new DataColumn("Giave", typeof(string)));
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow NewRow = DataTable_Decrypt.NewRow();
                    NewRow["Machuyentau"] = data.Rows[i]["Machuyentau"].ToString();
                    NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                    NewRow["Thoigianchay"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Thoigianchay"].ToString(), true);
                    NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                    NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                    NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                    NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                    NewRow["TenTau"] = data.Rows[i]["MaTau"].ToString();
                    NewRow["GiaVe"] = data.Rows[i]["GiaVe"].ToString();

                    DataTable_Decrypt.Rows.Add(NewRow);
                }

                return DataTable_Decrypt;
            }
            else if (flag == 2)
            {
                string sql = "SELECT * from ChuyenTau";
                DataTable data = ExecuteCommandText(sql);
                DataTable DataTable_Decrypt = new DataTable();
                DataTable_Decrypt.Columns.Add(new DataColumn("STT", typeof(int)));
                DataTable_Decrypt.Columns.Add(new DataColumn("ID", typeof(int)));
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
                    NewRow["ID"] = data.Rows[i]["MaChuyenTau"].ToString();
                    NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                    NewRow["Thoigianchay"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Thoigianchay"].ToString(), true);
                    NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                    NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                    NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                    NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                    NewRow["TenTau"] = data.Rows[i]["MaTau"].ToString();

                    DataTable_Decrypt.Rows.Add(NewRow);
                }

                return DataTable_Decrypt;
            }

            else
            {
                string sql = "SELECT * from ChuyenTau";
                DataTable data = ExecuteCommandText(sql);

                return data;
            }



        }
        public DataTable GetDataGaTau()
        {

            string sql = "SELECT * from GaTau";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("STT", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ID", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TTGaTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TinhTrangGa", typeof(string)));

            int a = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                a++;
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["STT"] = a.ToString();
                NewRow["ID"] = data.Rows[i]["id"];
                NewRow["TenGaTau"] = data.Rows[i]["TenGaTau"].ToString();
                NewRow["TTGaTau"] = data.Rows[i]["TTGaTau"].ToString();
                NewRow["TinhTrangGa"] = data.Rows[i]["TinhTrangGa"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;

        }
        public DataTable GetDataTau()
        {

            string sql = "SELECT * from Tau";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("STT", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ID", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TTTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TT", typeof(string)));

            int a = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                a++;
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["STT"] = a.ToString();
                NewRow["ID"] = data.Rows[i]["id"].ToString();
                NewRow["TenTau"] = data.Rows[i]["TenTau"].ToString();
                NewRow["TTTau"] = data.Rows[i]["TTTau"].ToString();
                NewRow["TT"] = data.Rows[i]["TT"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;

        }
        public DataTable SendInfo()
        {

            string sql = "SELECT * from ChuyenTau ORDER BY MaChuyenTau DESC";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("MaChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("SoVeToiDa", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("NgayDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ThoiGianChay", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDen", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("GiaVe", typeof(string)));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["MaChuyenTau"] = data.Rows[i]["MaChuyenTau"].ToString();
                NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                NewRow["Thoigianchay"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Thoigianchay"].ToString(), true);
                NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                NewRow["GiaVe"] = data.Rows[i]["GiaVe"].ToString();


                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable SendInfoSearch(string keyssea)
        {
            //    string keyssea = "Ga Bách Khoa";
            string sql = "SELECT * from ChuyenTau WHERE GaDi = '" + keyssea + "'OR [GaDen] = '" + keyssea + "'OR [NgayDi] = '" + keyssea + "'";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("MaChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("SoVeToiDa", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("NgayDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ThoiGianChay", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDen", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("GiaVe", typeof(string)));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["MaChuyenTau"] = data.Rows[i]["MaChuyenTau"].ToString();
                NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                NewRow["Thoigianchay"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Thoigianchay"].ToString(), true);
                NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                NewRow["GiaVe"] = data.Rows[i]["GiaVe"].ToString();





                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable SendInfoSearch_lonhon(string keyssea)
        {
            //    string keyssea = "Ga Bách Khoa";
            string sql = "SELECT * from ChuyenTau WHERE GiaVe > 200";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("MaChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("SoVeToiDa", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("NgayDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ThoiGianChay", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDen", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("GiaVe", typeof(string)));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["MaChuyenTau"] = data.Rows[i]["MaChuyenTau"].ToString();
                NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                NewRow["Thoigianchay"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Thoigianchay"].ToString(), true);
                NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                NewRow["GiaVe"] = data.Rows[i]["GiaVe"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable SendInfoSearch_bang(string keyssea)
        {
            //    string keyssea = "Ga Bách Khoa";
            string sql = "SELECT * from ChuyenTau WHERE GiaVe = 200";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("MaChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("SoVeToiDa", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("NgayDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ThoiGianChay", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDen", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("GiaVe", typeof(string)));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["MaChuyenTau"] = data.Rows[i]["MaChuyenTau"].ToString();
                NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                NewRow["Thoigianchay"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Thoigianchay"].ToString(), true);
                NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                NewRow["GiaVe"] = data.Rows[i]["GiaVe"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }
        public DataTable SendInfoSearch_nhohon(string keyssea)
        {
            //    string keyssea = "Ga Bách Khoa";
            string sql = "SELECT * from ChuyenTau WHERE GiaVe < 200";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("MaChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("SoVeToiDa", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenChuyenTau", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("NgayDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ThoiGianChay", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("TenGaDen", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("GiaVe", typeof(string)));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["MaChuyenTau"] = data.Rows[i]["MaChuyenTau"].ToString();
                NewRow["TenChuyenTau"] = data.Rows[i]["TenChuyenTau"].ToString();
                NewRow["NgayDi"] = data.Rows[i]["NgayDi"].ToString();
                NewRow["Thoigianchay"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["Thoigianchay"].ToString(), true);
                NewRow["SoVeToiDa"] = data.Rows[i]["SoVeToiDa"].ToString();
                NewRow["TenGaDi"] = data.Rows[i]["GaDi"].ToString();
                NewRow["TenGaDen"] = data.Rows[i]["GaDen"].ToString();
                NewRow["GiaVe"] = data.Rows[i]["GiaVe"].ToString();

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
        }

        public bool InsertOrder(int sovecapnhat, string tenct, string loaighe, int soluong, string thoigianchay, string ngaydi, int IDNguoiDung, string tinhtranghoadon, string Gadi, string Gaden, string total)
        {


            string Thoigianchay = Convert.ToString(thoigianchay);
            string NgayDi = Convert.ToString(ngaydi);
            Random random = new Random();
            int maDatCho = random.Next(1000, 2000);
            string MaDatCho = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, Convert.ToString(maDatCho), true);
            string Soluongve = Convert.ToString(soluong);
            string Tenchuyentau = Convert.ToString(tenct);


            string sql = " Insert Into HoaDon (MaKH,MaDatCho,NgayDat,ThoiGianChay,LoaiGhe,Soluongve,TinhTrangHoadon,Gadi,Gaden,Total,TenCT) values(@IDNguoiDung,@MaDatCho,@NgayDi,@Thoigianchay,@loaighe,@Soluongve,@tinhtranghoadon,@gadi,@gaden,@total,@tenct)";


            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();

            //them
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;

            command.Parameters.AddWithValue("@Thoigianchay", Thoigianchay);
            command.Parameters.AddWithValue("@NgayDi", NgayDi);
            command.Parameters.AddWithValue("@Soluongve", Soluongve);
            command.Parameters.AddWithValue("@MaDatCho", MaDatCho);
            command.Parameters.AddWithValue("@tinhtranghoadon", tinhtranghoadon);
            command.Parameters.AddWithValue("@loaighe", loaighe);
            command.Parameters.AddWithValue("@IDNguoiDung", IDNguoiDung);
            command.Parameters.AddWithValue("@gadi", Gadi);
            command.Parameters.AddWithValue("@gaden", Gaden);
            command.Parameters.AddWithValue("@total", total);
            command.Parameters.AddWithValue("@tenct", Tenchuyentau);
            int rows = command.ExecuteNonQuery();
            updatesoluongvetau(tenct, sovecapnhat);

            if (rows > 0)
                return true;
            else
                return false;

        }
        public void updatesoluongvetau(string tenct, int sovecapnhat)
        {
            string Sovcl = Convert.ToString(sovecapnhat);
            string Tenchuyentau = tenct;
            string sqlq = "UPDATE Chuyentau SET SoVeToiDa=@soveconlai WHERE [TenChuyenTau]='" + Tenchuyentau + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = sqlq;
            command1.Connection = con;
            command1.Parameters.AddWithValue("@soveconlai", Sovcl);
            command1.ExecuteNonQuery();

        }
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
        public DataTable GetOrder()
        {
            string tr = "New";
            string sql = "SELECT * from HoaDon WHERE TinhTrangHoadon = '" + tr + "'";

            //string sql = "select Soluongve,LoaiGhe,NgayDat,ThoigianChay,MaHD,total,Gaden,Gadi,TenDayDu,TenDangNhap,SoDienThoai,Email,DiaChi from HoaDon dv, nguoidung nd where nd.ID=dv.MaKH AND dv.TinhTrangHoadon = '" + tr + "'";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("Soluong", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Loaighe", typeof(string)));
            //  DataTable_Decrypt.Columns.Add(new DataColumn("TenDangNhap", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("ThoigianChay", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("NgayDat", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("MaHD", typeof(int)));



            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();


                NewRow["MaHD"] = Convert.ToInt32(data.Rows[i]["MaHD"].ToString());
                //  NewRow["TenDangNhap"] = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Decrypt(key, data.Rows[i]["TenDangNhap"].ToString(), true);
                NewRow["Loaighe"] = Convert.ToString(data.Rows[i]["LoaiGhe"].ToString());
                NewRow["Soluong"] = Convert.ToString(data.Rows[i]["Soluongve"].ToString());
                NewRow["NgayDat"] = Convert.ToString(data.Rows[i]["NgayDat"].ToString());
                NewRow["ThoigianChay"] = Convert.ToString(data.Rows[i]["ThoigianChay"].ToString());

                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
            // return data;

        }

        public DataTable GetHistory(int id)
        {
            string sql = "SELECT * from HoaDon WHERE[MaKH] = '" + id + "'";
            //    string sql = "select Soluongve,LoaiGhe,NgayDat,ThoigianChay,MaHD,total,Gaden,Gadi,TenDayDu,TenDangNhap,SoDienThoai,Email,DiaChi from HoaDon dv, nguoidung nd where nd.ID=dv.MaKH";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("MaHD", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Tenct", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Gadi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Gaden", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Ngaydi", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Loaighe", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Thoigianchay", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("soluong", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Total", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Tinhtrang", typeof(string)));


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["MaHD"] = Convert.ToInt32(data.Rows[i]["MaHD"].ToString());
                NewRow["Tenct"] = Convert.ToString(data.Rows[i]["TenCT"].ToString());
                NewRow["Gadi"] = Convert.ToString(data.Rows[i]["Gadi"].ToString());
                NewRow["Gaden"] = Convert.ToString(data.Rows[i]["Gaden"].ToString());
                NewRow["Ngaydi"] = Convert.ToString(data.Rows[i]["NgayDat"].ToString());
                NewRow["Loaighe"] = Convert.ToString(data.Rows[i]["LoaiGhe"].ToString());
                NewRow["Thoigianchay"] = Convert.ToString(data.Rows[i]["ThoiGianChay"].ToString());
                NewRow["soluong"] = Convert.ToString(data.Rows[i]["Soluongve"].ToString());
                NewRow["Total"] = Convert.ToString(data.Rows[i]["Total"].ToString());
                NewRow["Tinhtrang"] = Convert.ToString(data.Rows[i]["TinhTrangHoadon"].ToString());
                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
            // return data;

        }
        public DataTable GetHoaDon()
        {
            string sql = "SELECT * from HoaDon";
            //    string sql = "select Soluongve,LoaiGhe,NgayDat,ThoigianChay,MaHD,total,Gaden,Gadi,TenDayDu,TenDangNhap,SoDienThoai,Email,DiaChi from HoaDon dv, nguoidung nd where nd.ID=dv.MaKH";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("STT", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("MaHD", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Tenct", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Total", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Tinhtrang", typeof(string)));

            int a = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                a++;
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["STT"] = a;
                NewRow["MaHD"] = Convert.ToInt32(data.Rows[i]["MaHD"].ToString());
                NewRow["Tenct"] = Convert.ToString(data.Rows[i]["TenCT"].ToString());
                NewRow["Total"] = Convert.ToString(data.Rows[i]["Total"].ToString());
                NewRow["Tinhtrang"] = Convert.ToString(data.Rows[i]["TinhTrangHoadon"].ToString());
                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
            // return data;

        }
        public DataTable GetHoaDonLoc(string mact)
        {
            string sql = "SELECT * from HoaDon WHERE[TenCT] LIKE '%" + mact + "%'";
            //    string sql = "select Soluongve,LoaiGhe,NgayDat,ThoigianChay,MaHD,total,Gaden,Gadi,TenDayDu,TenDangNhap,SoDienThoai,Email,DiaChi from HoaDon dv, nguoidung nd where nd.ID=dv.MaKH";
            DataTable data = ExecuteCommandText(sql);

            DataTable DataTable_Decrypt = new DataTable();
            DataTable_Decrypt.Columns.Add(new DataColumn("STT", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("MaHD", typeof(int)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Tenct", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Total", typeof(string)));
            DataTable_Decrypt.Columns.Add(new DataColumn("Tinhtrang", typeof(string)));

            int a = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                a++;
                DataRow NewRow = DataTable_Decrypt.NewRow();
                NewRow["STT"] = a;
                NewRow["MaHD"] = Convert.ToInt32(data.Rows[i]["MaHD"].ToString());
                NewRow["Tenct"] = Convert.ToString(data.Rows[i]["TenCT"].ToString());
                NewRow["Total"] = Convert.ToString(data.Rows[i]["Total"].ToString());
                NewRow["Tinhtrang"] = Convert.ToString(data.Rows[i]["TinhTrangHoadon"].ToString());
                DataTable_Decrypt.Rows.Add(NewRow);
            }

            return DataTable_Decrypt;
            // return data;

        }
        public bool DeleteCT(int mahd)
        {
            string sql = "DELETE FROM HoaDon WHERE MaHD='" + mahd + "'";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;


            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;

        }

        public bool Deletedata_CT(int mahd)
        {

            string sql = "DELETE FROM ChuyenTau WHERE MaChuyenTau='" + mahd + "'";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;


            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;

        }
        public bool Deletedata_GT(int mahd)
        {

            string sql = "DELETE FROM GaTau WHERE id='" + mahd + "'";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;


            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;

        }
        public bool Deletedata_T(int mahd)
        {

            string sql = "DELETE FROM Tau WHERE id='" + mahd + "'";
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = con;


            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;

        }

        public DataTable GetCT_Update(int mact)
        {
            OpenConnection();
            string sql = "SELECT * from ChuyenTau WHERE MaChuyenTau='" + mact + "'";

            SqlCommand command = new SqlCommand(sql, connection);
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


        public bool Capnhatchuyentau(int mact, string tenchuyentau, string ngaykhoihanh, string thoigiandi, string gaden, string gadi, string matau, string sovetoida, string soluongvecho1nguoi, int giave)
        {

            string Tenchuyentau = tenchuyentau;
            string Ngaykhoihanh = ngaykhoihanh;
            string Thoigiandi = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, thoigiandi, true);
            string Soluongvecho1nguoi = Command_Main.Encrypt_Decrypt_DataBase.DataBase_Encrypt(key, soluongvecho1nguoi, true);
            string soluongvetoida = Convert.ToString(sovetoida);
            //   string sql = " Insert Into Chuyentau (Tenchuyentau,ThoigianChay,GaDi,GaDen,SoVeToiDa,MaTau,NgayDi,SoLuongVe,GiaVe,MaCN) values(@Tenchuyentau,@Thoigiandi,@gadi,@gaden,@soluongvetoida,@matau,@Ngaykhoihanh,@Soluongvecho1nguoi,@giave,@macn)";


            string sqlq = "UPDATE ChuyenTau SET Tenchuyentau=@Tenchuyentau,ThoigianChay=@Thoigiandi,GaDi=@gadi,GaDen=@gaden,SoVeToiDa=@soluongvetoida,MaTau=@matau,NgayDi=@Ngaykhoihanh,SoLuongVe=@Soluongvecho1nguoi,GiaVe=@giave WHERE [MaChuyenTau]='" + mact + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlq;
            command.Connection = con;
            command.Parameters.AddWithValue("@Soluongvecho1nguoi", Soluongvecho1nguoi);

            command.Parameters.AddWithValue("@Tenchuyentau", Tenchuyentau);
            command.Parameters.AddWithValue("@Ngaykhoihanh", Ngaykhoihanh);


            command.Parameters.AddWithValue("@Thoigiandi", Thoigiandi);
            command.Parameters.AddWithValue("@soluongvetoida", soluongvetoida);

            command.Parameters.AddWithValue("@gaden", gaden);
            command.Parameters.AddWithValue("@gadi", gadi);

            command.Parameters.AddWithValue("@matau", matau);
            command.Parameters.AddWithValue("@giave", giave);

            int rows = command.ExecuteNonQuery();

            if (rows > 0)

                return true;

            else
                return false;

        }

        public bool CapnhatGaTau(int mact, string tenchuyentau, string ngaykhoihanh, string thoigiandi)
        {

            string sqlq = "UPDATE GaTau SET TenGaTau=@TenGaTau,TTGaTau=@TTGaTau,TinhTrangGa=@TinhTrangGa WHERE [id]='" + mact + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlq;
            command.Connection = con;

            command.Parameters.AddWithValue("@TenGaTau", tenchuyentau);
            command.Parameters.AddWithValue("@TTGaTau", ngaykhoihanh);


            command.Parameters.AddWithValue("@TinhTrangGa", thoigiandi);


            int rows = command.ExecuteNonQuery();

            if (rows > 0)

                return true;

            else
                return false;

        }
        public void capnhattrangthaihoadon(string mahd, string tt)
        {

            string sqlq = "UPDATE HoaDon SET TinhTrangHoadon=@tt WHERE [MaHD]='" + mahd + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlq;
            command.Connection = con;

            command.Parameters.AddWithValue("@tt", tt);

            command.ExecuteNonQuery();


        }
        public bool CapnhatTau(int mact, string tenchuyentau, string ngaykhoihanh, string thoigiandi)
        {

            string sqlq = "UPDATE Tau SET TenTau=@TenGaTau,TTTau=@TTGaTau,TT=@TinhTrangGa WHERE [id]='" + mact + "'";
            //update
            SqlConnection con = new SqlConnection(strConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlq;
            command.Connection = con;

            command.Parameters.AddWithValue("@TenGaTau", tenchuyentau);
            command.Parameters.AddWithValue("@TTGaTau", ngaykhoihanh);
            command.Parameters.AddWithValue("@TinhTrangGa", thoigiandi);


            int rows = command.ExecuteNonQuery();

            if (rows > 0)

                return true;

            else
                return false;

        }
    }
}
