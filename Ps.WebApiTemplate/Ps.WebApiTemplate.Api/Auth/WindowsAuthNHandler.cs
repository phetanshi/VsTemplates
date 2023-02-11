using Microsoft.AspNetCore.Authorization;
using Ps.WebApiTemplate.Data;
using Ps.WebApiTemplate.Data.DbModels;

namespace Ps.WebApiTemplate.Api.Auth
{
    public class WindowsAuthNHandler : AuthorizationHandler<WindowsAuthNRequirement>
    {
        public WindowsAuthNHandler(IRepository repository)
        {
            Repository = repository;
        }
        public IRepository Repository { get; }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WindowsAuthNRequirement requirement)
        {
            if(context.User.Identity.IsAuthenticated)
            {
                var emp = Repository.GetById<Employee>(x => x.UserId.ToLower() == context.User.Identity.Name.ToLower());
                if(emp != null)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
