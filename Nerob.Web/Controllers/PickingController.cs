using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nerob.Web.Controllers
{
    // This is a Web API, it just can handle data and return data to the HTML
    public class PickingController : ApiController
    {
        // GET: api/Picking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Picking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Picking
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Picking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Picking/5
        public void Delete(int id)
        {
        }
    }
}
