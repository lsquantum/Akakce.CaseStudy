using Akakce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akakce.Domain.Entities;

[Table("User")]
public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
