﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TenmoServer.Models;
using TenmoServer.Security;
using TenmoServer.Security.Models;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;

        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

         Account balance = new Account();
        public decimal GetBalance(int accountId)
        {
            decimal returnBalance = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT balance FROM accounts WHERE account_id = @account_id", conn);
                    cmd.Parameters.AddWithValue("@account_id", accountId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read()) 
                        
                    {
                        
                        balance = GetAccountFromReader(reader);
                        returnBalance = balance.balance;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnBalance;
        }
        private Account GetAccountFromReader(SqlDataReader reader)
        {
            Account account = new Account()
            {
                account_id = Convert.ToInt32(reader["account_id"]),
                user_id = Convert.ToInt32(reader["user_id"]),
                balance = Convert.ToInt32(reader["balance"]),
               
            };

            return account;
        }
    }
}