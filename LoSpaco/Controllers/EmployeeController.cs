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
    public class EmployeeController : ApiController
    {
        [ActionName("GetList")]
        public IEnumerable<Employee> GetList()
        {
            return EmployeeDAO.GetList();
        }

        [ActionName("GetById")]
        public Employee GetById(uint id)
        {
            return EmployeeDAO.GetById(id);
        }
    }
}
