using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TenmoController : ControllerBase

    {

        private static IAccountDAO accountDAO;


    

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
        public ActionResult<Account> GetAccountById(int id)
        {
            Account account = accountDao.Get(id);

            if (account != null)
            {
                return account;
            }
            else
            {
                return NotFound();
            }

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

        [HttpPut("transactions/{id}")]
        public ActionResult<User> ApproveTransaction(int id)
        {
            return null;
        }



    }
}
