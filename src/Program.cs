using atdd_v2_dotnet.Data;
using atdd_v2_dotnet.Middleware;
using atdd_v2_dotnet.Service;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<LogisticService, LogisticService>();

builder.Services.AddSingleton(new ConsumerBuilder<Ignore, string>(new ConsumerConfig
{
    GroupId = "production",
    BootstrapServers = "kafka.tool.net:9094",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = true
}).Build());
builder.Services.AddHostedService<KafkaConsumerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TokenValidationMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();