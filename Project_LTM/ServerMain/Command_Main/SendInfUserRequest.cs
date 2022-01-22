using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class SendInfUserRequest
    {
        public string ID { get; set; }
        public string Password { get; set; }

        public SendInfUserRequest(string id, string pass)
        {
            this.ID = id;
            this.Password = pass;
        }
    }
}
