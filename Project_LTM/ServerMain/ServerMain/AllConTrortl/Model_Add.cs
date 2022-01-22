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
    public partial class Model_Add : UserControl
    {
        DBconnection connectionn = new DBconnection();
        string stre;
        public Model_Add()
        {
            InitializeComponent();

        }

        private void login_Click(object sender, EventArgs e)
        {

            string CN = FmDoashboard.stree2;
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
            string giave = guna2NumericUpDown1.Text;

            bool check = connectionn.CheckChuyentau(tenchuyentau);
            if (tbTenchuyentau.Text == "")
            {
                MessageBox.Show("vui long nhâp đầy đủ thông tin");
            }
            else if (check == true)
            {
                MessageBox.Show("Tên chuyển tàu đã tồn tại");
            }
            else
            {
                DBconnection connectionn = new DBconnection();
                bool them = connectionn.ThemChuyenTau(tenchuyentau, ngaykhoihanh, thoigiandi, gaden, gadi, matau, sovetoida, soluongvecho1nguoi, giave, CN);
                if (them == true)
                {
                    tbTenchuyentau.Text = "";
                    MessageBox.Show("Thêm thành công");
                    this.Hide();

                }
                else
                    MessageBox.Show("Thêm thất bại");
                this.Hide();

            }

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Soluongve_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Model_Add_Load(object sender, EventArgs e)
        {

            timer1.Start();
            stre = FmDoashboard.stree2;

            Tentau.DisplayMember = "TenTau";
            Tentau.ValueMember = "id";
            Tentau.DataSource = connectionn.GetTau();
            tbGaden.DisplayMember = "TenGaTau";
            tbGaden.ValueMember = "id";
            tbGaden.DataSource = connectionn.GetGa();


            loadgadi();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stre = FmDoashboard.stree2;
        }
        public void loadgadi()
        {
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
        }
    }
}
