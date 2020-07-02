using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        Transfer CreateTransfer(Transfer transfer);

        bool ApproveTransfer(int transferId);

        bool RejectTransfer(int transferId);

        string GetTransferStatus(int transferId);

        Transfer GetTransfer(int transferId);

        List<Transfer> GetPastTransfers();
    }
}
