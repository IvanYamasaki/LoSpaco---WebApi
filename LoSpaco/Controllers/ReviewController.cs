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
        public IEnumerable<Review> GetList(ushort id)
        {
            return ReviewDAO.GetList(id);
        }

        [ActionName("Insert")]
        public void Insert(uint id, string name, string review, float rating)
        {
            ReviewDAO.Insert(id, name, review, rating);
        }
    }
}
