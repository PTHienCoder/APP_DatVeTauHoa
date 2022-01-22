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
    public partial class Update_T : Form
    {
        string name, desc, status;
        int mct;
        string stre = FmDoashboard.stree2;

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public Update_T(int mact, string name, string desc, string status)
        {
            this.mct = mact;
            this.name = name;
            this.desc = desc;
            this.status = status;
            InitializeComponent();
        }

        private void Update_T_Load(object sender, EventArgs e)
        {
            tbTenchuyentau.Text = name;
            guna2TextBox1.Text = desc;
            guna2ComboBox1.Text = status;
        }

        private void login_Click(object sender, EventArgs e)
        {
            string tengatau = tbTenchuyentau.Text;
            string Thongtin = Convert.ToString(guna2TextBox1.Text);
            string tinhtrang = Convert.ToString(guna2ComboBox1.Text);
            if (tbTenchuyentau.Text == "" || guna2TextBox1.Text == "")
            {
                MessageBox.Show("vui long nhâp đầy đủ thông tin");
            }
            else
            {

                if (stre == "Đà Nẵng")
                {
                    DBconnection0 connectionn0 = new DBconnection0();
                    bool them = connectionn0.CapnhatTau(mct, tengatau, Thongtin, tinhtrang);
                    if (them == true)
                    {
                        tbTenchuyentau.Text = "";
                        guna2TextBox1.Text = "";
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
                    bool them = connectionn1.CapnhatTau(mct, tengatau, Thongtin, tinhtrang);
                    if (them == true)
                    {
                        tbTenchuyentau.Text = "";
                        guna2TextBox1.Text = "";
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
                    bool them = connectionn2.CapnhatTau(mct, tengatau, Thongtin, tinhtrang);
                    if (them == true)
                    {
                        tbTenchuyentau.Text = "";
                        guna2TextBox1.Text = "";
                        MessageBox.Show("Cập nhật thành công");
                        this.Hide();

                    }
                    else
                        MessageBox.Show("Cập nhật thất bại");
                    this.Hide();


                }
            }
        }
    }
}
