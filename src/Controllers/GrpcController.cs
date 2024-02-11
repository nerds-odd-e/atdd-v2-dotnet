using System.Text;
using System.Text.Json;
using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

using Grpc.Net.Client;
using GrpcGreeterClient;

namespace atdd_v2_dotnet.Controllers;

[Route("api/grpc")]
[ApiController]
public class GrpcController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:3254");
        var client = new Greeter.GreeterClient(channel);

        var request = new HelloRequest { Name = "John" };
        var response = client.SayHello(request);

        return Ok(response.Message);
    }
}