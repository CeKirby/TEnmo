using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TenmoController : ControllerBase
    {
        private static IUserDAO _userDAO;
        private static ITransferDAO _transferDAO;
        public TenmoController()
        {

        }

        [HttpGet("users")]
        public List<User> ListUsers()
        {
            return null;
        }

        [HttpGet("user/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return null;

        }

        [HttpGet("user/account/{id}")]
        public ActionResult<User> GetAccountById(int id)
        {
            return null;

        }
        [HttpGet("transactions/{id}")]
        public ActionResult<User> GetTransactionsByUserId(int id)
        {
            return null;

        }

        [HttpPost("transactions/new")]
        public ActionResult<User> NewTransaction()
        {
            return null;

        }


        [HttpPut("transfer/{id}")]
        public ActionResult<Transfer> UpdateTransfer(int id, Transfer transferToUpdate, int updateCode)
        {
            Transfer existingTransfer = 
            if(transferToUpdate = 
            if(updateCode == 2)
            {

            } else if (updateCode == 3)
            {

            }
            return
        }


    }
}
