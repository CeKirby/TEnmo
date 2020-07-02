using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.Models;
using TenmoServer.DAO;

namespace TenmoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase

    {

        private static IAccountDAO accountDAO;
        private static IUserDAO userDAO;
        private static ITransferDAO transferDAO;

        public UserController(IAccountDAO _accountDAO, IUserDAO _userDAO, ITransferDAO _transferDAO)
        {
            accountDAO = _accountDAO;
            userDAO = _userDAO;
            transferDAO = _transferDAO;
        }

        [HttpGet]
        public List<User> ListUsers()
        {
            return userDAO.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {

            return userDAO.GetUserById(id);

        }

        [HttpGet("account/{id}")]
        public ActionResult<Account> GetAccountById(int id)
        {
            Account account = accountDAO.GetAccount(id);

            if (account != null)
            {
                return account;
            }
            else
            {
                return NotFound();
            }

        }

        //[HttpGet("account/{id}")]
        //public ActionResult<decimal> GetAccountBalance(int id)
        //{
        //    decimal balance = _accountDAO.GetBalance(id);
        //    if (balance > 0)
        //    {
        //        return balance;
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //}
        [HttpGet("transfer/{id}")]
        public ActionResult<User> GetTransactionsByUserId(int id)
        {
            return null;

        }

        [HttpPost("transfer/new")]
        public ActionResult<User> NewTransfer()
        {
            return null;

        }

        [HttpPut("transfer/{id}")]
        public ActionResult<User> ApproveTransaction(int id)
        {
            return null;
        }


    }
}
