using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Demo
{
    public partial class IteamVeTau : UserControl
    {
        private string namect, gadi, gaden, thoigian, ngay, giave;
        private int slconlai;
        private Button btt;


        private static IteamVeTau _instance;

        public static IteamVeTau Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IteamVeTau();
                return _instance;
            }
        }
        public IteamVeTau()
        {
            InitializeComponent();
        }

        public string NameCT
        {
            get { return namect; }
            set { namect = value; label7.Text = value; }
        }
        public Button Buntt
        {
            get { return btt; }
            set { btt = value;}
        }
        public string Gadi
        {
            get { return gadi; }
            set { gadi = value; label8.Text = value; }
        }

        public void book_Click(object sender, EventArgs e)
        {
            MessageBox.Show("booooooooooooooooooooooook");
        }

        public string Gaden
        {
            get { return gaden; }
            set { gaden = value; label9.Text = value; }
        }
        public string Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; label10.Text = value; }
        }
        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; label11.Text = value; }
        }
        public string Giave
        {
            get { return giave; }
            set { giave = value; label14.Text = value; }
        }
        public int Slveconlai
        {
            get { return slconlai; }
            set { slconlai = value; label12.Text = value.ToString(); }
        }
     

    }
}
