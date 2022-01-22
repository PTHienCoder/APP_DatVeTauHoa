using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class DeleteBookingRequest
    {

        public string mahd { get; set; }

        public DeleteBookingRequest(string mahd)
        {
            this.mahd = mahd;
        }
    }
}
