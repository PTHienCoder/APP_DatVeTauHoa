using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class SendRequestHistoty
    {
        public int ID { get; set; }

        public SendRequestHistoty(int id)
        {
            this.ID = id;
        }
    }
}
