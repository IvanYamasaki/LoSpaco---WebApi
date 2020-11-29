using LoSpacoWebAPi.DAO;
using LoSpacoWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoSpaco.Controllers
{
    public class AccountController : ApiController
    {
        [ActionName("GetByEmail")]
        public Account GetByEmail(string email)
        {
            return AccountDAO.GetByEmail(email);
        }
        
        [ActionName("GetById")]
        public Account GetById(uint id)
        {
            return AccountDAO.GetById(id);
        }
        
        [ActionName("Insert")]
        public dynamic Insert(string email, string password)
        {
            return AccountDAO.Insert(email, password);
        }
        
        [ActionName("Login")]
        public bool Login(string email, string password)
        {
            return AccountDAO.Login(email, password);
        }
        
        [ActionName("UpdatePassword")]
        public dynamic UpdatePassword(string currentPassword, string newPassword)
        {
            return AccountDAO.UpdatePassword(currentPassword, newPassword);
        }
    }
}
