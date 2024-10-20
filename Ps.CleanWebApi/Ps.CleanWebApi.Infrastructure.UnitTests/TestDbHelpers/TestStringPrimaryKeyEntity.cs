namespace Ps.CleanWebApi.Infrastructure.UnitTests.TestDbHelpers;

public class TestStringPrimaryKeyEntity : DatabaseBaseEntity<string>
{
    public string Name { get; set; }
}
