using System.Buffers.Text;
using System.Text;
using System.Text.Json;
using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace atdd_v2_dotnet.Controllers;

[Route("users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public UsersController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost("login")]
    public IActionResult Post([FromBody] User user)
    {
        var loginUser = _appDbContext.Users.First(e => e.UserName == user.UserName && e.Password == user.Password);
        Response.Headers.Add("token", Token.MakeToken(loginUser.UserName));
        return Ok();
    }

    // [HttpGet]
    // public IEnumerable<User> Get()
    // {
    //     return appDbContext.Users.ToList();
    // }
    //
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

    // @Data
    // @Accessors(chain = true)
    // public static class Token {
    //     public static final int EXPIRATION = 300;
    //     private String user;
    //     private long now = Instant.now().getEpochSecond();
    //
    //     public static String makeToken(String userName) {
    //         return new Token().setUser(userName).toString();
    //     }
    //
    //     @SneakyThrows
    //     public static Token parseToken(String tokenString) {
    //         try {
    //             return new ObjectMapper().readValue(Base64.getDecoder().decode(tokenString), Token.class);
    //         } catch (Exception ignore) {
    //             return null;
    //         }
    //     }
    //
    //     @JsonIgnore
    //     public boolean isExpired() {
    //         return Instant.now().getEpochSecond() - getNow() > EXPIRATION;
    //     }
    //
    //     @Override
    //     @SneakyThrows
    //     public String toString() {
    //         return Base64.getEncoder().encodeToString(new ObjectMapper().writeValueAsBytes(this));
    //     }
    // }


public class Token
{
    public long now { get; set; } = DateTime.Now.Ticks;
    public string user { get; set; }

    public static string MakeToken(string userName)
    {
        return new Token { user = userName }.Create();
    }

    private string Create() {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(this)));
    }
}