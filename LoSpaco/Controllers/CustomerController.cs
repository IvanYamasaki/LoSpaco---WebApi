using LoSpacoWebAPi.DAO;
using LoSpacoWebAPi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LoSpaco.Controllers
{
    public class CustomerController : ApiController
    {
        [ActionName("GetList")]
        public IEnumerable<Customer> GetList()
        {
            return CustomerDAO.GetList();
        }

        [ActionName("GetById")]
        public Customer GetById(uint id)
        {
            return CustomerDAO.GetById(id);
        }
    }
}
