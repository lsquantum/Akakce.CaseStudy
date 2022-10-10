using Akakce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akakce.Domain.Entities;

[Table("Stock")]
public class Stock : AuditableBaseEntity
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
}