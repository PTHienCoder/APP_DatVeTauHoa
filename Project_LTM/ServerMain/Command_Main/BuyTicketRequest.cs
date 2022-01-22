using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class BuyTicketRequest
    {
        public int Soveconlai { get; set; }
        public string TenCT { get; set; }
        public string Gaden { get; set; }
        public string tongtien { get; set; }
        public string Gadi { get; set; }

        public string loaighe { get; set; }
        public double GiaGhe { get; set; }
        public string Thoigianchay { get; set; }
        public string Ngaydi { get; set; }
        public int Soluong { get; set; }
        public int Idnguoidung { get; set; }
        public BuyTicketRequest(int soveconlai, string tenct, string loaighe, int soluong, string thoigianchay, string ngaydi, int idnguoidung, string Gaden, string Gadi, string tongtien)
        {
            this.Soveconlai = soveconlai;
            this.TenCT = tenct;
            this.loaighe = loaighe;
            this.Soluong = soluong;
            this.Thoigianchay = thoigianchay;
            this.Ngaydi = ngaydi;
            this.Idnguoidung = idnguoidung;
            this.Gaden = Gaden;
            this.Gadi = Gadi;
            this.tongtien = tongtien;


        }
    }
}
