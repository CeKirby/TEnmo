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
        //Transfer transfer = new Transfer();
        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        /// <summary>
        /// Create new transfer from authorized user to listed user
        /// </summary>
        /// <returns></returns>
        public int SendTransfer(int userIdFrom, int UserIdTo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find transfer by transferId
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public Transfer GetTransfer(int transferId)
        {
            Transfer transfer = new Transfer();
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
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return transfer;
        }
        /// <summary>
        /// Check status of transfer
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns></returns>
        public string GetTransferStatus(int transferId)
        {
            string status = "Pending";
            Transfer transfer = GetTransfer(transferId);
            if (transfer.TransferStatusId == 1)
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

            return status;
        }
        /// <summary>
        /// Authorized user approves transfer
        /// </summary>
        /// <returns></returns>
        public bool ApproveTransfer(int transferId)
        {
            bool wasAproved = false;
            Transfer transfer = GetTransfer(transferId);
            if(transfer != null)
            {
                wasAproved = false;
            } else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE * FROM transfer WHERE transfer_id = @transferid SET transfer_status_id = '2'", conn);
                        cmd.Parameters.AddWithValue("@transferid", transferId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if(rowsAffected == 1)
                        {
                            wasAproved = true;
                        }
                    }
                }
                catch (SqlException)
                {
                    throw;
                }
            }
            
            return wasAproved;
        }
        /// <summary>
        /// Authorized user rejects transfer
        /// </summary>
        /// <returns></returns>
        public bool RejectTransfer(int transferId)
        {
            bool wasAproved = false;
            Transfer transfer = GetTransfer(transferId);
            if (transfer != null)
            {
                wasAproved = false;
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE * FROM transfer WHERE transfer_id = @transferid SET transfer_status_id = '3'", conn);
                        cmd.Parameters.AddWithValue("@transferid", transferId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            wasAproved = true;
                        }
                    }
                }
                catch (SqlException)
                {
                    throw;
                }
            }

            return wasAproved;
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
