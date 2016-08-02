using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchedulerAPI.Controllers
{
    public class APIPersonController : ApiController
    {
        // GET: api/DummyPerson
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DummyPerson/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DummyPerson
        public string Post([FromBody]string FirstName, [FromBody]string LastName, [FromBody]string Address1, [FromBody]string Address2, [FromBody]string City, [FromBody]string State, [FromBody]string Zip)
        {
            // Call the SP in the database (model)
            return "value";
        }

        // PUT: api/DummyPerson/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DummyPerson/5
        public void Delete(int id)
        {
        }
    }
}
