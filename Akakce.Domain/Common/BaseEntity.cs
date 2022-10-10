using System.ComponentModel.DataAnnotations.Schema;

namespace Akakce.Domain.Common;
public abstract class BaseEntity
{
    //Entity PrimaryKey
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual long Id { get; set; }
}