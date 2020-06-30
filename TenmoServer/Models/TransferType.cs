using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class TransferType
    {
        // request(1) or send(2)
        public int transfer_type_id { get; set; }

        public string transfer_type_desc { get; set; }
    }
}
