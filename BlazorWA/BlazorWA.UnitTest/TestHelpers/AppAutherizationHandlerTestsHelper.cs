namespace BlazorWA.UnitTest.TestHelpers
{
    public static class AppAutherizationHandlerTestsHelper
    {
        public static IConfiguration GetConfigurationForTest()
        {
            var inMemorySettings = new Dictionary<string, string>();
            inMemorySettings.Add("Api:Login", "user/login");
            IConfiguration configuration = new ConfigurationBuilder()
                                            .AddInMemoryCollection(inMemorySettings)
                                            .Build();

            return configuration;
        }
        public static Mock<IAccessTokenService> GetIAccessTokenServiceMockObject()
        {
            var accessTokenServiceMock = new Mock<IAccessTokenService>();
            accessTokenServiceMock.Setup(x => x.GetAccessTokenAsync(It.IsAny<string>())).ReturnsAsync("testtoken");
            return accessTokenServiceMock;
        }
    }
}
