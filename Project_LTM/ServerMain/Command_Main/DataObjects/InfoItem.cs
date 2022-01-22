using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main.DataObjects
{
    [Serializable]
    public class InfoItem
    {
        public string TenChuyentau { get; set; }

        public string ThoiGianChay { get; set; }
        public string GaDi { get; set; }
        public string GaDen { get; set; }
        public string Ngaydi { get; set; }
        public string Giave { get; set; }
        public int Soluongvetau { get; set; }


        public InfoItem(int soluongvetau, string tenChuyentau, string Ngaydi, string thogianchay, string tengadi, string tengaden, string Giave)
        {
            this.Soluongvetau = soluongvetau;
            this.GaDen = tengaden;
            this.GaDi = tengadi;
            this.ThoiGianChay = thogianchay;
            this.TenChuyentau = tenChuyentau;
            this.Ngaydi = Ngaydi;
            this.Giave = Giave;
        }
    }
}
