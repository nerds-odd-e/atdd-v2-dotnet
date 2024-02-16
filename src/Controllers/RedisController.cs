using System.Text;
using System.Text.Json;
using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

using Grpc.Net.Client;
using GrpcGreeterClient;
using StackExchange.Redis;

namespace atdd_v2_dotnet.Controllers;

[Route("api/redis")]
[ApiController]
public class RedisController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var redis = ConnectionMultiplexer.Connect("redis.tool.net").GetDatabase();
        return Ok(redis.StringGet("redis").ToString());
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var redis = (await ConnectionMultiplexer.ConnectAsync("redis.tool.net")).GetDatabase();
        using var reader = new StreamReader(Request.Body, leaveOpen: true);
        redis.StringSet("redis", await reader.ReadToEndAsync());
        return Ok();
    }
}