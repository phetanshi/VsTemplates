using PsTest.UI.Auth;
using System.Security.Claims;

namespace PsTest.UnitTest.UI.Auth
{
    public class AppAuthenticationStateProviderTests
    {
        [Fact]
        public async Task GetAuthenticationStateAsync_WhenLoginIsValid_ReturnAuthenticaitonStateObjectWithUserIdClaim()
        {
            var userServiceHandlerMock = new Mock<IUserServiceHandler>();

            userServiceHandlerMock.Setup(x => x.LoginAsync()).ReturnsAsync(new PsTest.UI.Helpers.ApiResponse { IsSuccess = true });
            userServiceHandlerMock.Setup(x => x.GetLoginUserDetailsAsync()).ReturnsAsync(new Person { UserId = "testuserid", FirstName = "TestFirstName" });
            AppAuthenticationStateProvider obj = new AppAuthenticationStateProvider(userServiceHandlerMock.Object);
            var response = await obj.GetAuthenticationStateAsync();
            var userIdClaim = response.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier);
            Assert.Equal("testuserid", userIdClaim.Value);
        }

        [Fact]
        public async Task GetAuthenticationStateAsync_WhenLoginIsNotValid_ReturnEmptyAuthenticaitonStateObject()
        {
            var userServiceHandlerMock = new Mock<IUserServiceHandler>();
            userServiceHandlerMock.Setup(x => x.LoginAsync()).ReturnsAsync(default(PsTest.UI.Helpers.ApiResponse));
            userServiceHandlerMock.Setup(x => x.GetLoginUserDetailsAsync()).ReturnsAsync(default(Person));
            AppAuthenticationStateProvider obj = new AppAuthenticationStateProvider(userServiceHandlerMock.Object);
            var response = await obj.GetAuthenticationStateAsync();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetAuthenticationStateAsync_WhenLoginIsValidButUserDetailsNotFound_ReturnEmptyAuthenticaitonStateObject()
        {
            var userServiceHandlerMock = new Mock<IUserServiceHandler>();

            userServiceHandlerMock.Setup(x => x.LoginAsync()).ReturnsAsync(new PsTest.UI.Helpers.ApiResponse { IsSuccess = true });
            userServiceHandlerMock.Setup(x => x.GetLoginUserDetailsAsync()).ReturnsAsync(default(Person));

            AppAuthenticationStateProvider obj = new AppAuthenticationStateProvider(userServiceHandlerMock.Object);
            var response = await obj.GetAuthenticationStateAsync();
            Assert.NotNull(response);
        }
    }
}
