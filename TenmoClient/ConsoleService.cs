using System;
using System.Collections.Generic;
using TenmoClient.Data;


namespace TenmoClient
{
    public class ConsoleService
    {

        /// <summary>
        /// Prompts for transfer ID to view, approve, or reject
        /// </summary>
        /// <param name="action">String to print in prompt. Expected values are "Approve" or "Reject" or "View"</param>
        /// <returns>ID of transfers to view, approve, or reject</returns>
        public int PromptForTransferID(string action)
        {
            Console.WriteLine("");
            Console.Write("Please enter transfer ID to " + action + " (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int actionId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return actionId;
            }
        }
        public void PrintBalance(Account balance)
        {
            {
                Console.WriteLine("Your balance is: $" + balance.balance);
            }
        }
        public LoginUser PromptForLogin()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            string password = GetPasswordFromConsole("Password: ");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        private string GetPasswordFromConsole(string displayMessage)
        {
            string pass = "";
            Console.Write(displayMessage);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("");
            return pass;
        }

        public void DisplayUsers(List<API_User> users)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("  Users ID      ||  Name                    ");
            Console.WriteLine("--------------------------------------------");
            foreach (API_User user in users)
            {
                Console.WriteLine($"  {user.UserId}      ||  {user.Username}");
            }
        }

        public decimal VerifyAccountBalancePrompt(decimal userBalance, decimal amountToSend, string usernameTo)
        {
            decimal amount = amountToSend;
            while (userBalance < amount)
            {
                Console.WriteLine("You do not have enough TEBucks in your account to make this transfer.");
                Console.WriteLine("Change amount (1) or return to the Main Menu(0)?");
                int response = Convert.ToInt32(Console.ReadLine());
                if (response == 1)
                {
                    Console.WriteLine($"Input the amount you want to send to {usernameTo}:");
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                else if (response == 0)
                {
                    amount = -1;
                }
            }

            return amount;
        }

        public void DisplaySendTransfer(decimal amount, string userToUsername)
        {
            string date = DateTime.Today.ToString("dd/MM/yyyy");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($" Send to - {userToUsername} | Amount: ${amount} | {date}");
            Console.WriteLine("--------------------------------------------");
        }
        public void DisplayRequestTransfer(decimal amount, string userToUsername)
        {
            string date = DateTime.Today.ToString("dd/MM/yyyy");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($" Request from - {userToUsername} | Amount: ${amount} | {date}");
            Console.WriteLine("--------------------------------------------");
        }

        public void DisplayTransfers(List<Transfer> transfers)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Transfer Id");
            Console.WriteLine("--------------------------------------------");
            foreach (Transfer transfer in transfers)
            {
                string type = TransferType(transfer);
                Console.WriteLine($"Transfer Id: {transfer.TransferId} -   ${transfer.Amount}.");
            }
        }

        public void DisplayTransferDetails(Transfer transfer)
        {
            string type = TransferType(transfer);
            string status = TransferStatus(transfer);

            Console.WriteLine(" Id: " + transfer.TransferId);
            Console.WriteLine(" Type: " + type);
            Console.WriteLine(" Status: " + status);
            Console.WriteLine(" Account From: " + transfer.AccountFrom);
            Console.WriteLine(" Account To: " + transfer.AccountTo);
            Console.WriteLine(" Amount: " + transfer.Amount);
        }

        public string TransferType(Transfer transfer)
        {
            string type = "";
            if (transfer.TransferTypeId == 2)
            {
                type = "Sent";
            }
            else if (transfer.TransferTypeId == 1)
            {
                type = "Recieved";
            }

            return type;
        }

        public string TransferStatus(Transfer transfer)
        {
            string status = "";
            if (transfer.TransferStatusId == 1)
            {
                status = "Pending";
            } else if (transfer.TransferStatusId == 2)
            {
                status = "Approved";
            } else if (transfer.TransferStatusId == 3)
            {
                status = "Rejected";
            }
            return status;
        }

    }
}

