﻿using System;
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
    [Authorize]

    public class TenmoController : ControllerBase

    {

        private static IAccountDAO _accountDAO;


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
            //Account account = _accountDao.Get(id);

            //if (account != null)
            //{
            //    return account;
            //}
            //else
            //{
            //    return NotFound();
            //}
            return null;

        }

        [HttpGet("user/account/{id}")]
        public ActionResult<decimal> GetAccountBalance(int id)
        {
            decimal balance = _accountDAO.GetBalance(id);
            if (balance > 0)
            {
                return balance;
            }
            else
            {
                return NotFound();
            }

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

        [HttpPut("transactions/{id}")]
        public ActionResult<User> ApproveTransaction(int id)
        {
            return null;
        }


    }
}
