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

        private static IAccountDAO _accountDAO;
        private static ITransferDAO _transferDAO;


        public UserController(IAccountDAO accountDAO, ITransferDAO transferDAO)
            {
                _accountDAO = accountDAO;
                _transferDAO = transferDAO;

            }
        
        [HttpGet]
        public List<User> ListUsers()
        {
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return null;

        }

        [HttpGet("account/{id}")]
        public ActionResult<Account> GetAccountById(int id)
        {
            Account account = _accountDAO.GetAccount(id);

            if (account != null)
            {
                return account;
            }
            else
            {
                return NotFound();
            }

        }


        [HttpGet("transfer/{id}")]
        public ActionResult<Transfer> GetPastTransactions(int id)
        {
            
                Transfer transfer = _transferDAO.GetTransfer(id);
                if (transfer != null)
                {
                return transfer;
                }
                return NotFound();
            

        }

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
