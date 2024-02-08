using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace atdd_v2_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(AppDbContext appDbContext) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return appDbContext.Users.ToList();
        }

        // // GET api/<API>/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }
        //
        // // POST api/<API>
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }
        //
        // // PUT api/<API>/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE api/<API>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
