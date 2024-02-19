using System.Text.Json;
using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Models;
using Confluent.Kafka;

namespace atdd_v2_dotnet.Service;

public class KafkaConsumerService : BackgroundService
{
    private readonly IConsumer<Ignore, string> consumer;
    private readonly IServiceScopeFactory scopeFactory;

    public KafkaConsumerService(IConsumer<Ignore, string> consumer, IServiceScopeFactory scopeFactory)
    {
        this.consumer = consumer;
        this.scopeFactory = scopeFactory;
        consumer.Subscribe("dotnet.data");
        Console.WriteLine("task start");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Run(() =>
        {
            while (!stoppingToken.IsCancellationRequested)
                try
                {
                    Console.WriteLine("task running");
                    var message = consumer.Consume(stoppingToken);
                    Console.WriteLine($"Consume message: {message.Message.Value}");
                    using var scope = scopeFactory.CreateScope();
                    var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    appDbContext.Users.Add(JsonSerializer.Deserialize<User>(message.Message.Value));
                    appDbContext.SaveChanges();
                }
                catch
                    (OperationCanceledException e)
                {
                    Console.WriteLine($"Consume canceled: {e.Message}");
                    consumer.Close();
                    break;
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Consume error: {e.Error.Reason}");
                }
        }, stoppingToken);
    }
}