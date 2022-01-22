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
    public partial class Model_Add1 : UserControl
    {
        public Model_Add1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            
           if (tbTenchuyentau.Text == "" || guna2TextBox1.Text == "")
            {
                MessageBox.Show("vui long nhâp đầy đủ thông tin");
            }
            else
            { 

                DBconnection connectionn = new DBconnection();
            string tengatau = tbTenchuyentau.Text;
            string Thongtin = Convert.ToString(guna2TextBox1.Text);
            string Chinhanh = Convert.ToString(tbGadi.Text);
            string tinhtrang = Convert.ToString(guna2ComboBox1.Text);
            bool them = connectionn.ThemGaTau(tengatau, Thongtin, Chinhanh, tinhtrang);
            if (them == true)
            {
                tbTenchuyentau.Text = "";
               guna2TextBox1.Text = "";
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

        private void Model_Add1_Load(object sender, EventArgs e)
        {
        
        }
    }
}
