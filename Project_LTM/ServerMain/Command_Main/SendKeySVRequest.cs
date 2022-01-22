using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class SendKeySVRequest
    {
        public string KEYSV { get; set; }
        public SendKeySVRequest(string keysv)
        {
            this.KEYSV = keysv;
        }
    }
}
