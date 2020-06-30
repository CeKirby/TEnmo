using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {
        private readonly string connectionString;
        Transfer transfer = new Transfer();
        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public bool ApproveTransfer()
        {
            throw new NotImplementedException();
        }

        public string GetTransferStatus(int transferId)
        { 
            string status = "Pending";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM transfer WHERE transfer_id = @transferid", conn);
                    cmd.Parameters.AddWithValue("@transferid", transferId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        transfer = GetTransferFromReader(reader);
                    }
                    if(transfer.TransferStatusId == 1)
                    {
                        status = "Pending";
                    }
                    else if (transfer.TransferStatusId == 2)
                    {
                        status = "Approved";
                    }
                    else if (transfer.TransferStatusId == 3)
                    {
                        status = "Rejected";
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return status;
        }

        public bool RejectTransfer()
        {
            throw new NotImplementedException();
        }

        public int SendTransfer()
        {
            throw new NotImplementedException();
        }
        private Transfer GetTransferFromReader(SqlDataReader reader)
        {
            Transfer t = new Transfer()
            {
                TransferId = Convert.ToInt32(reader["transfer_type_id"]),
                TransferTypeId = Convert.ToInt32(reader["transfer_type_id"]),
                TransferStatusId = Convert.ToInt32(reader["transfer_status_id"]),
                AccountFrom = Convert.ToInt32(reader["account_from"]),
                AccountTo = Convert.ToInt32(reader["account_to"]),
                Amount = Convert.ToInt32(reader["amount"]),
            };

            return t;
        }
    }
}
