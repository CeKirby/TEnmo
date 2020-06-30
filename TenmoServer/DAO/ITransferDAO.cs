using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        int SendTransfer();

        bool ApproveTransfer();

        bool RejectTransfer();

        string GetTransferStatus(int statusId);

    }
}
