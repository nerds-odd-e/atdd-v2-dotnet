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
}

public class Token
{
    public long now { get; set; } = DateTime.Now.Second;
    public string user { get; set; }

    public static string MakeToken(string userName)
    {
        return new Token { user = userName }.Create();
    }

    private string Create()
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(this)));
    }

    public static bool ValidToken(string? tokenString)
    {
        try
        {
            var validToken =
                JsonSerializer.Deserialize<Token>(Encoding.UTF8.GetString(Convert.FromBase64String(tokenString)));
            return DateTime.Now.Second - validToken.now < 300;
        }
        catch
        {
            return false;
        }
    }
}