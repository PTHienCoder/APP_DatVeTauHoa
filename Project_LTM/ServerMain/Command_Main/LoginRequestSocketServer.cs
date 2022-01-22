using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    public class LoginRequestSocketServer
    {
        public string Id;
        public string Pass;
        public LoginRequestSocketServer(string id, string pass)
        {
            this.Id = id;
            this.Pass = pass;
        }
    }
}
