namespace Ps.CleanWebApi.Infrastructure.UnitTests;

public static class InMemoryConfigurationHelper
{
    public static IConfiguration GetTestInMemoryConfiguration()
    {
        var settings = new Dictionary<string, string?>();
        settings.Add("test", "TestValue");
        IConfiguration config = new ConfigurationBuilder()
                                    .AddInMemoryCollection(settings)
                                    .Build();
        return config;
    }
}