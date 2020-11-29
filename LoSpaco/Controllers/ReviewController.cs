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
    public class ReviewController : ApiController
    {
        [ActionName("GetList")]
        public IEnumerable<Review> GetList(string service)
        {
            return ReviewDAO.GetList(service);
        }

        [ActionName("Insert")]
        public void Insert(string name, string review, float rating)
        {
            ReviewDAO.Insert(name, review, rating);
        }
    }
}
