using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main.DataObjects
{
    [Serializable]
    public class InfoUser
    {
        public string Tendangnhap { get; set; }
        public string Matkhau { get; set; }
        public string Diachi { get; set; }
        public string Sodienthoai { get; set; }
        public string Sotien { get; set; }
        public string TenDayDu { get; set; }
        public string Email { get; set; }
        public int Id;
        public InfoUser(int id, string tendangnhap, string matkhau, string sodienthoai, string diachi, string sotien, string tendaydu, string Email)
        {
            this.Email = Email;
            this.Tendangnhap = tendangnhap;
            this.Matkhau = matkhau;
            this.Diachi = diachi;
            this.Sodienthoai = sodienthoai;
            this.Sotien = sotien;
            this.TenDayDu = tendaydu;
            this.Id = id;
        }
    }
}
