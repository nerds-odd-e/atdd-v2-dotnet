using Microsoft.AspNetCore.Mvc;

namespace atdd_v2_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<API>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<API>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<API>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<API>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<API>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
