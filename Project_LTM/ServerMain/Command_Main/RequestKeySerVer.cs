using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
   public class RequestKeySerVer
    {
        public string KEYSV { get; set; }
        public string KEYsearch { get; set; }
        public RequestKeySerVer(string keysearch , string keysv)
        {
            this.KEYSV = keysv;
            this.KEYsearch = keysearch;
        }
    }
}
