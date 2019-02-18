using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IamcoreProject.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace IamcoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(IWritableOptions<ConfigModel> options)
        {
            var valueString = options.Value.FieldString;
            var valueInt = options.Value.Fieldint;

            options.Update(t =>
            {
                t.FieldString = "value1";
                t.Fieldint = 1;
            });
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
