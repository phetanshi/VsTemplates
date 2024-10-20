using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ps.CleanWebApi.Infrastructure.UnitTests.TestDbHelpers;

public class TestEmployeeEntity : DatabaseBaseEntity<int>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public override int Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }

    public ICollection<TestLanAccountEntity>? LanAccounts { get; set; }
}
