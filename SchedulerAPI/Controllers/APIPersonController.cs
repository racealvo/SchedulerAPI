using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchedulerAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SchedulerAPI.Controllers
{
    public class APIPersonController : ApiController
    {
        // GET: api/DummyPerson
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        [HttpGet]
        [Route("api/Person/{PersonID}")]
        public JObject Index(Int16 PersonID)
        {
            PersonModels personModel = new Models.PersonModels();
            Person person = personModel.GetPerson(PersonID);
            string json = JsonConvert.SerializeObject(person);
            return JObject.Parse(json);

            //TODO: PersonID is out of range - error?
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
