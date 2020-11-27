using LoSpacoWebAPi.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoSpaco.Controllers
{
    public class CartController : ApiController
    {

        [ActionName("GetList")]
        public List<dynamic> GetList()
        {
            return CartDAO.GetList();
        }
        
        [ActionName("GetByName")]
        public object[] GetByName(string name)
        {
            return CartDAO.GetByName(name);
        }

        [ActionName("GetTotalPrice")]
        public object GetTotalPrice(int id)
        {
            return CartDAO.GetTotalPrice();
        }

        [ActionName("InsertItem")]
        public void InsertItem(string name, byte quantity)
        {
            CartDAO.InsertItem(name, quantity);
        }
        
        [ActionName("RemoveItem")]
        public object[] RemoveItem(string name)
        {
            return CartDAO.RemoveItem(name);
        }
        
        [ActionName("UpdateQuantity")]
        public object[] UpdateQuantity(string name, byte qty)
        {
            return CartDAO.UpdateQuantity(name, qty);
        }

        [ActionName("IsCartEmpty")]
        public bool IsCartEmpty()
        {
            return CartDAO.IsCartEmpty();
        }
                
        [ActionName("GetQuantity")]
        public byte GetQuantity(string name)
        {
            return CartDAO.GetQuantity(name);
        }



        
        // POST: api/Cart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cart/5
        public void Delete(int id)
        {
        }
    }
}
