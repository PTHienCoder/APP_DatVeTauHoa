using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main.DataObjects
{
    [Serializable]
    public class Item_Gatau
    {
        public string name { get; set; }
        public int id { get; set; }

        public Item_Gatau(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
