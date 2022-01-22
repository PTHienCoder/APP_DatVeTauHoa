using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main.DataObjects
{
    [Serializable]
    public class ItemHis
    {
        public int maHD { get; set; }
        public string TenChuyentau { get; set; }

        public string GaDi { get; set; }
        public string GaDen { get; set; }
        public string Ngaydi { get; set; }
        public string LoaiGhe { get; set; }
        public string ThoiGianChay { get; set; }
        public string Soluongve { get; set; }
        public string Total { get; set; }
        public string TinhTrang { get; set; }




        public ItemHis(int mahd, string tenct, string gadi, string gaden, string ngaydi, string loaighe, string thoigianchay, string soluong, string total, string tìnhtrang)
        {
            this.maHD = mahd;
            this.TenChuyentau = tenct;
            this.GaDi = gadi;
            this.GaDen = gaden;
            this.Ngaydi = ngaydi;
            this.LoaiGhe = loaighe;
            this.ThoiGianChay = thoigianchay;
            this.Soluongve = soluong;
            this.Total = total;
            this.TinhTrang = tìnhtrang;
        }
    }
}
