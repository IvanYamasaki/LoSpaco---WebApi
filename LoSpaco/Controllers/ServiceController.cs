using LoSpacoWebAPi.DAO;
using LoSpacoWebAPi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LoSpaco.Controllers
{
    public class ServiceController : ApiController
    {
        //[ActionName("GetQuery")]
        //public string GetQuery(int index, string category, int? startPrice, int? endPrice)
        //{   
        //    return ServiceDAO.GetQuery(index, category, startPrice, endPrice);
        //}

        [ActionName("GetList")]
        public IEnumerable<Service> GetList()
        {   
            return ServiceDAO.GetList();
        }
                
        [ActionName("GetList")]
        public List<Service> GetList(int orderIndex, string category, int? sp, int? ep)
        {
            return ServiceDAO.GetList(orderIndex, category, sp, ep);
        }
        
        [ActionName("GetById")]
        public Service GetById(ushort id)
        {
            return ServiceDAO.GetById(id);
        }

        [ActionName("GetByName")]
        public Service GetByName(string name)
        {
            return ServiceDAO.GetByName(name);
        }

        [ActionName("GetMinPrice")]
        public int GetMinPrice()
        {
            return ServiceDAO.GetMinPrice();
        }

        [ActionName("GetMaxPrice")]
        public int GetMaxPrice()
        {
            return ServiceDAO.GetMaxPrice();
        }

        [ActionName("GetByCategoryId")]
        public List<Service> GetByCategoryId(ushort id)
        {
            return ServiceDAO.GetByCategoryId(id);
        }
    }
}
