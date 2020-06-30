using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class TransferStatus
    {
        //Pending(1) Approved(2) Rejected(3)
        public int transfer_status_id { get; set; }

        public string transfer_status_desc { get; set; }
    }
}
