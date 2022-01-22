using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command_Main.DataObjects;
namespace Command_Main
{
    [Serializable]
    public class SendRepone_Search 
    {
        public ItemSearch[] Itemseach { get; set; }
    
    }
}
