using System.ComponentModel.DataAnnotations.Schema;

namespace atdd_v2_dotnet.Models;

public class OrderLine
{
    public int Id { get; set; }
    public string ItemName { get; set; }

    [Column(TypeName = "decimal(10,2)")] public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}