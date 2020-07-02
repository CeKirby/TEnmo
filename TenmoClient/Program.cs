using System;
using System.Collections.Generic;
using TenmoClient.Data;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoClient
{
    class Program
    {
        private static readonly ConsoleService consoleService = new ConsoleService();
        private static readonly AuthService authService = new AuthService();
        private static int loggedInUserId = UserService.GetUserId();
        private static decimal userBalance;


        static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            int loginRegister = -1;
            while (loginRegister != 1 && loginRegister != 2)
            {
                Console.WriteLine("Welcome to TEnmo!");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Register");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out loginRegister))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else if (loginRegister == 1)
                {
                    while (!UserService.IsLoggedIn()) //will keep looping until user is logged in
                    {
                        Data.LoginUser loginUser = consoleService.PromptForLogin();
                        API_User user = authService.Login(loginUser);
                        if (user != null)
                        {
                            UserService.SetLogin(user);
                            loggedInUserId = UserService.GetUserId();
                        }
                    }
                }
                else if (loginRegister == 2)
                {
                    bool isRegistered = false;
                    while (!isRegistered) //will keep looping until user is registered
                    {
                        Data.LoginUser registerUser = consoleService.PromptForLogin();
                        isRegistered = authService.Register(registerUser);
                        if (isRegistered)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Registration successful. You can now log in.");
                            loginRegister = -1; //reset outer loop to allow choice for login
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }

            MenuSelection();
        }

        private static void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to TEnmo! Please make a selection: ");
                Console.WriteLine("1: View your current balance");
                Console.WriteLine("2: View your past transfers");
                Console.WriteLine("3: View your pending requests");
                Console.WriteLine("4: Send TE bucks");
                Console.WriteLine("5: Request TE bucks");
                Console.WriteLine("6: Log in as different user");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else if (menuSelection == 1)
                {
                    Data.Account account = authService.GetAccount(loggedInUserId);
                    userBalance = account.balance;
                    consoleService.PrintBalance(account);
                }
                else if (menuSelection == 2)
                {

                }
                else if (menuSelection == 3)
                {

                }
                else if (menuSelection == 4)
                {
                    try
                    {
                        //print users to select recipient
                        List<API_User> users = authService.GetUsers();
                        consoleService.DisplayUsers(users);

                        //select user
                        Console.WriteLine("Input the UserId of the person who you want to send TEBucks:");
                        int userId = Convert.ToInt32(Console.ReadLine());
                        API_User userTo = authService.GetUser(userId);

                        //input amount 
                        Console.WriteLine($"Input the amount you want to send to {userTo.Username}:");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());

                        //verify amount < account balance
                        amount = consoleService.VerifyAccountBalancePrompt(userBalance, amount, userTo.Username);
                        if (amount < 0)
                        {
                            MenuSelection();
                        }
                        consoleService.DisplayTransfer(amount, userTo.Username);
                        //Confirm transfer is still wanted
                        Console.WriteLine("Confirm Transfer? Y/N");
                        string response = Console.ReadLine().ToLower();
                        if (response != "y")
                        {
                            //TODO FIX
                            MenuSelection();
                        }
                        else
                        {
                            //create transfer (transfer contains (userIdFrom, userIdTo, amount, transfer type = 2)
                            Data.Account accountFrom = authService.GetAccount(loggedInUserId);
                            Data.Account accountTo = authService.GetAccount(userTo.UserId);
                            Data.Transfer newTransfer = new Data.Transfer(2, 2, accountFrom.accountId, accountTo.accountId, amount);

                        }

                        
                        //receiver balance increased by amount
                        //sender balance decreased by amount
                        //transferStatus = Approved(2)
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("You entered an invalid Response. Please try again.");
                    }
                }
                else if (menuSelection == 5)
                {
                    //print users to select user for request
                    //select user
                    //input amount requested (transfer contains (userIdFrom, userIdTo, amount) transfer type = 1
                    //transferStatus = Pending(1)
                    //userFrom approve/deny request
                    //verify amount < userFrom account balance
                    //reciever balance increased by amount
                    //sender balance decreased by amount
                    //TransferStatus changed to Approved or Rejected
                }
                else if (menuSelection == 6)
                {
                    Console.WriteLine("");
                    UserService.SetLogin(new API_User()); //wipe out previous login info
                    Run(); //return to entry point
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
