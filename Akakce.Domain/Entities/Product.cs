using Akakce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akakce.Domain.Entities;

[Table("Product")]
public class Product : AuditableBaseEntity
{
    public string Name { get; set; } = null!;
    public string Barcode { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Rate { get; set; }
}