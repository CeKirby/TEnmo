using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        int SendTransfer(int userIdFrom, int UserIdTo);

        bool ApproveTransfer(int transferId);

        bool RejectTransfer(int transferId);

        string GetTransferStatus(int transferId);

    }
}
