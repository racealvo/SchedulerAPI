using SchedulerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace SchedulerAPI.Controllers
{
    public class PersonController : Controller
    {
        // GET: api/Person
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Person
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Route("{id:int}")]
        public ActionResult Index(int PersonID)
        {
            return View();
        }

        [HttpDelete]
        [Route("~/delete/{PersonID}")]
        public ActionResult Delete(string PersonID)
        {
            var x = 1;

            return View();
        }

        [HttpPut]
        public ActionResult Index(string PersonID, string FirstName, string LastName, string Address1, string Address2, string City, string State, string Zip)
        {
            var x = 1;

            return View();
        }
    }
}
