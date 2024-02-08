using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace atdd_v2_dotnet.Models;

public class Order
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Code { get; set; }
    public string ProductName { get; set; }
    [JsonIgnore]
    public string RecipientName { get; set; }
    [JsonIgnore]
    public string RecipientMobile { get; set; }
    [JsonIgnore]
    public string RecipientAddress { get; set; }
    [JsonIgnore]
    public string DeliverNo { get; set; }
    [JsonIgnore]
    public DateTime DeliveredAt { get; set; }
    public string Status { get; set; }
    [JsonIgnore]
    public ICollection<OrderLine> Lines { get; set; }

    [Column(TypeName = "decimal(10,2)")] public decimal Total { get; set; }
}