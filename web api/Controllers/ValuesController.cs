using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api.Controllers
{
    public class ValuesController : ApiController
    {
        [ActionName("get1")]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ActionName("get2")]
        public IEnumerable<string> Get2()
        {
            return new string[] { "value3", "value4" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [ActionName("post")]
        // POST api/values
        public void Post([FromBody]string value)
        {
        }
        [ActionName("put")]
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [ActionName("delete")]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}