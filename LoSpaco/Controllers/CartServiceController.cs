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
    public class CartServiceController : ApiController
    {
        [ActionName("GetList")]
        public IEnumerable<CartService> GetList()
        {
            return CartServiceDAO.GetList();
        }

        [ActionName("GetByName")]
        public CartService GetByName(string name)
        {
            return CartServiceDAO.GetByName(name);
        }
    }
}
