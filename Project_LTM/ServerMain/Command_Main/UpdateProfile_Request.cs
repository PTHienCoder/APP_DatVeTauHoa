using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{

    [Serializable]
    public class UpdateProfile_Request
    {

        public string Diachi { get; set; }
        public string Sodienthoai { get; set; }
        public string TenDayDu { get; set; }
        public string Email { get; set; }
        public int Id;
        public UpdateProfile_Request(int id, string tendaydu, string sodienthoai, string diachi, string Email)
        {
            this.Email = Email;
            this.Diachi = diachi;
            this.Sodienthoai = sodienthoai;
            this.TenDayDu = tendaydu;
            this.Id = id;
        }
    }
}
