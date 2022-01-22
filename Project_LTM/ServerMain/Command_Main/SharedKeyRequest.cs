using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class SharedKeyRequest
    {
        public DateTime RequestTime { get; set; }

        public byte[] SharedKey { get; set; }
    }
}
