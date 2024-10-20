namespace Ps.CleanWebApi.Infrastructure.UnitTests.TestDbHelpers;

public class TestDbModelForCompositeKeyEntity : DatabaseBaseEntity<int>
{
    public int IdTwo { get; set; }
    public string Name { get; set; }
}
