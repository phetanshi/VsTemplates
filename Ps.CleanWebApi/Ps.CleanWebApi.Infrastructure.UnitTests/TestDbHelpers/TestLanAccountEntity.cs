using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ps.CleanWebApi.Infrastructure.UnitTests.TestDbHelpers;

public class TestLanAccountEntity : DatabaseBaseEntity<string>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("ID")]
    public override string Id { get; set; }

    [ForeignKey(nameof(Employee))]
    public int? EmployeeId { get; set; }
    public TestEmployeeEntity? Employee { get; set; }
}
