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
    public partial class Model_Add2 : UserControl
    {
    DBconnection connectionn = new DBconnection();
        public Model_Add2()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
          if (tbTenchuyentau.Text == "" || guna2TextBox1.Text =="")
            {
                MessageBox.Show("vui long nhâp đầy đủ thông tin");
            }
            else
            { 

                string tentau = tbTenchuyentau.Text;
            string Thongtin = Convert.ToString(guna2TextBox1.Text);
            int magatau = Convert.ToInt32(tbGadi.SelectedValue);
            string tinhtrang = Convert.ToString(guna2ComboBox1.Text);
            bool them = connectionn.ThemTau(tentau, Thongtin, magatau, tinhtrang);
            if (them == true)
            {
                    guna2TextBox1.Text = "";
                    tbTenchuyentau.Text = "";
                MessageBox.Show("Thêm thành công");
                this.Hide();

            }
            else
                MessageBox.Show("Thêm thất bại");
            this.Hide();
          }
        }

        private void Model_Add2_Load(object sender, EventArgs e)
        {
            

            tbGadi.DisplayMember = "TenGaTau";
            tbGadi.ValueMember = "id";
            tbGadi.DataSource = connectionn.GetGa();
               
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tbGadi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
