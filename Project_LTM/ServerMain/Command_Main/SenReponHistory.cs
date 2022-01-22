using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command_Main.DataObjects;
namespace Command_Main
{
    [Serializable]
    public class SenReponHistory
    {
        public ItemHis[] Items { get; set; }
    }
}
