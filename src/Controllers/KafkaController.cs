using System.Text;
using System.Text.Json;
using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Models;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

using Grpc.Net.Client;
using GrpcGreeterClient;

namespace atdd_v2_dotnet.Controllers;

[Route("api/kafka")]
[ApiController]
public class KafkaController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] KafkaMessage msg)
    {
        var producer = new ProducerBuilder<Null, string>(new ProducerConfig
        {
            BootstrapServers = "kafka.tool.net:9094"
        }).Build();
        producer.Produce("dotnet.message", new Message<Null, string>
        {
            Value = JsonSerializer.Serialize(msg)
        });
        producer.Flush();
        producer.Dispose();
        return Ok();
    }
}

public class KafkaMessage
{
    public string Name { get; set; }
}