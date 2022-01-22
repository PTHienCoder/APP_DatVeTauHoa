using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMain
{
    public partial class Update_CT : Form
    {
        int mact;
        string stre = FmDoashboard.stree2;
        DBconnection connectionn = new DBconnection();
        public Update_CT(int mact)
        {
            this.mact = mact;
       
            InitializeComponent();
        }

        private void Update_CT_Load(object sender, EventArgs e)
        {
     

            Tentau.DisplayMember = "TenTau";
            Tentau.ValueMember = "id";
            Tentau.DataSource = connectionn.GetTau();
            tbGaden.DisplayMember = "TenGaTau";
            tbGaden.ValueMember = "id";
            tbGaden.DataSource = connectionn.GetGa();


            tbGadi.DisplayMember = "TenGaTau";
            tbGadi.ValueMember = "id";


            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                tbGadi.DataSource = connectionn0.GetGa();
            }
            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();

                tbGadi.DataSource = connectionn1.GetGa();
            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                tbGadi.DataSource = connectionn2.GetGa();
            }
            loadIfct();

        }
        public void loadIfct()
        {

      

            if (stre == "Đà Nẵng")
            {
                DBconnection0 connectionn0 = new DBconnection0();
                DataTable ds = connectionn0.GetCT_Update(mact);
                if (ds != null)
                {
                    if (ds.Rows.Count > 0)
                    {

                        foreach (DataRow row in ds.Rows)
                        {
                             tbTenchuyentau.Text = row["TenChuyenTau"].ToString();
                          
                             tbGaden.Text = row["GaDen"].ToString();
                             tbGadi.Text = row["Gadi"].ToString();
                             Tentau.Text = row["MaTau"].ToString();
                             Soluongve.Text = row["SoVeToiDa"].ToString();
                             guna2NumericUpDown1.Text = row["GiaVe"].ToString();

                        }

                    }
                }

            }


            else if (stre == "Hồ Chí Minh")
            {
                DBconnection1 connectionn1 = new DBconnection1();
                DataTable ds = connectionn1.GetCT_Update(mact);
                if (ds != null)
                {
                    if (ds.Rows.Count > 0)
                    {

                        foreach (DataRow row in ds.Rows)
                        {
                            tbTenchuyentau.Text = row["TenChuyenTau"].ToString();

                            tbGaden.Text = row["GaDen"].ToString();
                            tbGadi.Text = row["Gadi"].ToString();
                            Tentau.Text = row["MaTau"].ToString();
                            Soluongve.Text = row["SoVeToiDa"].ToString();
                            guna2NumericUpDown1.Text = row["GiaVe"].ToString();

                        }

                    }
                }

            }
            else if (stre == "Hà Nội")
            {
                DBconnection2 connectionn2 = new DBconnection2();
                DataTable ds = connectionn2.GetCT_Update(mact);
                if (ds != null)
                {
                    if (ds.Rows.Count > 0)
                    {

                        foreach (DataRow row in ds.Rows)
                        {
                            tbTenchuyentau.Text = row["TenChuyenTau"].ToString();

                            tbGaden.Text = row["GaDen"].ToString();
                            tbGadi.Text = row["Gadi"].ToString();
                            Tentau.Text = row["MaTau"].ToString();
                            Soluongve.Text = row["SoVeToiDa"].ToString();
                            guna2NumericUpDown1.Text = row["GiaVe"].ToString();

                        }

                    }
                }


            }


        }

        private void login_Click(object sender, EventArgs e)
        {
            string tenchuyentau = tbTenchuyentau.Text;
            string ngaykhoihanh = Convert.ToString(Ngaydi.Text);
            string thoigiandi_h = Convert.ToString(giodi.Text);
            string thoigiandi_phut = Convert.ToString(phutdi.Text);
            string thoigiandi = thoigiandi_h + ':' + thoigiandi_phut;
            string gaden = tbGaden.Text;
            string gadi = tbGadi.Text;
            string matau = Tentau.Text;
            string soluongvecho1nguoi = "5";
            string sovetoida = Soluongve.Text;
            int giave = Convert.ToInt32(guna2NumericUpDown1.Text);


            if (tbTenchuyentau.Text == "")
            {
                MessageBox.Show("vui lòng nhâp đầy đủ thông tin");
            }
          
            else
            {

                            if (stre == "Đà Nẵng")
                            {
                              DBconnection0 connectionn0 = new DBconnection0();
                               bool them = connectionn0.Capnhatchuyentau(mact, tenchuyentau, ngaykhoihanh, thoigiandi, gaden, gadi, matau, sovetoida, soluongvecho1nguoi, giave);
                                    if (them == true)
                                    {
                                        tbTenchuyentau.Text = "";
                                        MessageBox.Show("Cập nhật thành công");
                                        this.Hide();

                                    }
                                    else
                                        MessageBox.Show("Cập nhật thất bại");
                                    this.Hide();
                            }


                            else if (stre == "Hồ Chí Minh")
                                  {
                                DBconnection1 connectionn1 = new DBconnection1();
                                bool them = connectionn1.Capnhatchuyentau(mact, tenchuyentau, ngaykhoihanh, thoigiandi, gaden, gadi, matau, sovetoida, soluongvecho1nguoi, giave);
                                if (them == true)
                                {
                                    tbTenchuyentau.Text = "";
                                    MessageBox.Show("Cập nhật thành công");
                                    this.Hide();

                                }
                                else
                                    MessageBox.Show("Cập nhật thất bại");
                                this.Hide();

                                 
                               }
                            else if (stre == "Hà Nội")
                            {
                                DBconnection2 connectionn2 = new DBconnection2();
                                bool them = connectionn2.Capnhatchuyentau(mact, tenchuyentau, ngaykhoihanh, thoigiandi, gaden, gadi, matau, sovetoida, soluongvecho1nguoi, giave);
                                if (them == true)
                                {
                                    tbTenchuyentau.Text = "";
                                    MessageBox.Show("Cập nhật thành công");
                                    this.Hide();

                                }
                                else
                                    MessageBox.Show("Cập nhật thất bại");
                                this.Hide();

                                 
                            }

            }
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
