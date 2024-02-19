using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace atdd_v2_dotnet.Models;

public class OrderLine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string ItemName { get; set; }

    [Column(TypeName = "decimal(10,2)")] public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int OrderId { get; set; }

    public Order? Order { get; set; }
}