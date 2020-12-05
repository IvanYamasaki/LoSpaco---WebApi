using LoSpacoWebAPi.DAO;
using LoSpacoWebAPi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LoSpaco.Controllers
{
    public class PackageController : ApiController
    {
        [ActionName("GetList")]
        public IEnumerable<Package> GetList()
        {
            return PackageDAO.GetList();
        }

        [ActionName("GetById")]
        public Package GetById(ushort id)
        {
            return PackageDAO.GetById(id);
        }       
        
        [ActionName("GetById")]
        public List<Service> GetServicesFromPackage(ushort id)
        {
            return PackageDAO.GetServicesFromPackage(id);
        }
        
        //[ActionName("GetCart")]
        //public Package GetCart(string name)
        //{
        //    return PackageDAO.GetCart(name);
        //}

        [ActionName("GetMaxPrice")]
        public int GetMaxPrice()
        {
            return PackageDAO.GetMaxPrice();
        }
        [ActionName("GetMinPrice")]
        public int GetMinPrice()
        {
            return PackageDAO.GetMinPrice();
        }
    }
}
