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

        [HttpGet("account/{userId}")]
        public ActionResult<Account> GetAccountById(int userId)
        {
            Account account = accountDAO.GetAccount(userId);

            if (account != null)
            {
                return account;
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("transfer/history/{accountId}")]
        public List<Transfer> GetPastTranfers(int accountId)
        {
            return transferDAO.GetPastTransfers(accountId);

        }

        [HttpGet("transfer/{id}")]
        public ActionResult<Transfer> GetTransferDetails(int id)
        {
            
                Transfer transfer = transferDAO.GetTransfer(id);
                if (transfer != null)
                {
                return transfer;
                }
                return NotFound();
            

        }

        [HttpPost("transfer")]
        public ActionResult<Transfer> NewTransfer(Transfer transfer)
        {
            Transfer added = transferDAO.CreateTransfer(transfer);
            return Created($"transfer/{added.TransferId}", added);

        }
        [HttpPut("account/{userId}")]
        public ActionResult<Account> UpdateAccount(int userId, Account updatedAccount)
        {
            Account existingAccount = accountDAO.GetAccount(userId);
            if (existingAccount == null)
            {
                return NotFound("Reservation does not exist");
            }

            Account result = accountDAO.UpdateAccount(userId, updatedAccount);
            return Ok(result);
        }

        [HttpPut("transfer/{id}")]
        public ActionResult<User> ApproveTransaction(int id)
        {
            return null;
        }


    }
}
