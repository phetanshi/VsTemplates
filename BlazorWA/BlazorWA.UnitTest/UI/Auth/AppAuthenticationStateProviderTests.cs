namespace BlazorWA.UnitTest.UI.Auth
{
    public class AppAuthenticationStateProviderTests
    {
        [Fact]
        public async Task GetAuthenticationStateAsync_WhenCalled_ReturnAuthenticaitonStateObject()
        {
            var userServiceHandlerMock = new Mock<IUserServiceHandler>();
            var accessTokenServiceMock = new Mock<IAccessTokenService>();

            userServiceHandlerMock.Setup(x => x.LoginAsync()).ReturnsAsync(new AuthenticationResponse { Token = "testtoken" });
            userServiceHandlerMock.Setup(x => x.GetLoginUserDetailsAsync()).ReturnsAsync(new UserVM { UserId = "testuserid", FirstName = "TestFirstName" });
            accessTokenServiceMock.Setup(x=>x.SetAccessTokenAsync(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            AppAuthenticationStateProvider obj = new AppAuthenticationStateProvider(userServiceHandlerMock.Object, accessTokenServiceMock.Object);
            var response = await obj.GetAuthenticationStateAsync();
            Assert.NotNull(response);
        }
    }
}
