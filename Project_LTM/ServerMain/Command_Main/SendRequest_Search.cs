using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class SendRequest_Search
    {
        public string keyseach { get; set; }
        public SendRequest_Search(string keyseach)
        {
            this.keyseach = keyseach;      
        }
    }
}
