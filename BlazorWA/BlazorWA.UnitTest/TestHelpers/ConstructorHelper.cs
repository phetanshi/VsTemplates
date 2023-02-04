namespace BlazorWA.UnitTest.TestHelpers
{
    public static class ConstructorHelper
    {
        public static IConfiguration GetTestConfigFile()
        {
            var inMemorySettings = new Dictionary<string, string>();
            inMemorySettings.Add("Api:Login", "user/login");
            inMemorySettings.Add("Api:Post", "user/post");
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

        public static HttpClient GetTestHttpClient()
        {
            var ctx = new TestContext();
            var mockHttp = ctx.Services.AddMockHttpClient();
            var httpUrl = "https://localhost";

            List<IdentityVM> users = new List<IdentityVM>
            {
                new IdentityVM { UserId="testuserid" }
            };

            IdentityVM userVM = new IdentityVM
            {
                FirstName = "test post response"
            };

            mockHttp.When($"{httpUrl}/user/post").RespondJson(userVM);
            var clinet = mockHttp.ToHttpClient();
            clinet.BaseAddress = new Uri(httpUrl + "/");

            return clinet;
        }
    }
}
