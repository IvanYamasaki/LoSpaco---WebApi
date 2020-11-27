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



        // POST: api/Package
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Package/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Package/5
        public void Delete(int id)
        {
        }
    }
}
