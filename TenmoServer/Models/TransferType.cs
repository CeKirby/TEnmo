using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class TransferType
    {
        // request(1) or send(2)
        public int TransferTypeId { get; set; }

        public string TransferTypeDesc { get; set; }
    }
}
