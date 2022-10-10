using Akakce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akakce.Domain.Entities;

[Table("Basket")]
public class Basket : AuditableBaseEntity
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; } = 1;

    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
}
