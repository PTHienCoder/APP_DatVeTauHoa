using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    public class LoginResponseSocketServercs
    {
        public bool success { get; set; }
        public string messenger { get; set; }
        public LoginResponseSocketServercs(bool Success, string Messenger)
        {
            this.success = success;
            this.messenger = Messenger;
        }

    }
}
