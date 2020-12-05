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
        public List<dynamic> GetList(ushort id)
        {
            return CartDAO.GetList(id);
        }
        
        [ActionName("GetCart")]
        public List<dynamic> GetCart(ushort id)
        {
            return CartDAO.GetCart(id);
        }
        
        [ActionName("GetTotalPrice")]
        public object GetTotalPrice(uint id)
        {
            return CartDAO.GetTotalPrice(id);
        }

        [ActionName("InsertItem")]
        public void InsertItem(uint id, string name, byte quantity)
        {
            CartDAO.InsertItem(id, name, quantity);
        }
        
        [ActionName("RemoveItem")]
        public object[] RemoveItem(uint id, string name)
        {
            return CartDAO.RemoveItem(id, name);
        }
        
        [ActionName("UpdateQuantity")]
        public object[] UpdateQuantity(uint id, string name, byte qty)
        {
            return CartDAO.UpdateQuantity(id, name, qty);
        }

        [ActionName("IsCartEmpty")]
        public bool IsCartEmpty(uint id)
        {
            return CartDAO.IsCartEmpty(id);
        }
                
        [ActionName("GetQuantity")]
        public byte GetQuantity(uint id, string name)
        {
            return CartDAO.GetQuantity(id, name);
        }
    }
}
