using System.ComponentModel.DataAnnotations.Schema;

namespace Akakce.Domain.Common;
public abstract class AuditableBaseEntity
{
    //Entity PrimaryKey
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual long Id { get; set; }

    //Created UserId
    public long CreatedBy { get; set; }

    //Date Created
    public DateTime Created { get; set; } = DateTime.Now;

    //Last Modified UserId
    public long? LastModifiedBy { get; set; }

    //Last Modified
    public DateTime? LastModified { get; set; }

    //Record Deleted
    public bool IsDeleted { get; set; } = false;
}