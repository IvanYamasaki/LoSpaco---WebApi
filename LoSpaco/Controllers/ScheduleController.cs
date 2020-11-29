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
    public class ScheduleController : ApiController
    {
        [ActionName("GetList")]
        public IEnumerable<Schedule> GetList()
        {
            return ScheduleDAO.GetList();
        }

        [ActionName("GetById")]
        public Schedule GetById(uint id)
        {
            return ScheduleDAO.GetById(id);
        }
    }
}
