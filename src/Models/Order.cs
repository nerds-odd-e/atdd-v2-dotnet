using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace atdd_v2_dotnet.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Code { get; set; }
    public string ProductName { get; set; }

    public string? RecipientName { get; set; }

    public string? RecipientMobile { get; set; }

    public string? RecipientAddress { get; set; }

    public string? DeliverNo { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public string Status { get; set; }

    public ICollection<OrderLine> Lines { get; set; } = new List<OrderLine>();

    [Column(TypeName = "decimal(10,2)")] public decimal Total { get; set; }
}