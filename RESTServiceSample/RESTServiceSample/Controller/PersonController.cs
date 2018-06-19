using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RESTServiceSample.Controller
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Microsoft.AspNetCore.Mvc.Controller
    {
        // GET: api/Person
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Glen", "Mr.Olsen" };
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return id.ToString();
        }
        
        // POST: api/Person
        [HttpPost]
        public void Post([FromBody]string value)
        {
            string a = "test";
        }
        
        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
