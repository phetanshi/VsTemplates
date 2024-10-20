using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ps.CleanWebApi.Infrastructure.Entities;

public abstract class DatabaseBaseEntity<TKeyType>
{
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual TKeyType Id { get; set; }

    [Column("IS_ACTIVE")]
    public bool IsActive { get; set; }

    [Column("DATE_CREATED")]
    public DateTime? DateCreated { get; set; }

    [Column("CREATED_BY")]
    public string? CreatedBy { get; set; }

    [Column("DATE_UPDATED")]
    public DateTime? DateUpdated { get; set; }

    [Column("UPDATED_BY")]
    public string? UpdatedBy { get; set; }
}
