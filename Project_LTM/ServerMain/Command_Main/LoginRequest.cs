using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class LoginRequest
    {
        public string ID { get; set; }
        public string Password { get; set; }

        public LoginRequest(string id, string pass)
        {
            this.ID = id;
            this.Password = pass;
        }
    }
}
