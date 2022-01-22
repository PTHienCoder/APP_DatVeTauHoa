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
    public partial class Login_admin : Form
    {
        DBconnection connectionn = new DBconnection();
        public Login_admin()
        {
            InitializeComponent();
        }

        public static string keySV = "";
        private void login_Click(object sender, EventArgs e)
        {
            keySV = guna2ComboBox1.Text;
            string tendangnhap = guna2TextBox1.Text;
            string password = Textbox_Pass.Text;
            if (tendangnhap == "" || password == "")
            {
                MessageBox.Show("Bạn Chưa nhập Tài khoản hoặc mật khẩu ");
            }
            else
            {
                bool success = connectionn.ValidateLoginServer(tendangnhap, password);

                if (success == true)
                {

                    FmDoashboard frm = new FmDoashboard();
                    frm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Đăng nhập thất bại");

            }
        }

            private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_admin_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }
    }
}
