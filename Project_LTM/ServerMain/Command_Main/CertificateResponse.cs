using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Command_Main
{
    [Serializable]
    public class CertificateResponse
    {
        public DateTime ResponseTime { get; set; }

        public RSAParameters PublicKey { get; set; }
    }
}
