using Microsoft.AspNetCore.Authorization;
using $ext_projectname$.Data;
using $ext_projectname$.Data.DbModels;
using System.Security.Claims;

namespace $safeprojectname$.Auth
{
    public class AppSpecificHandler : AuthorizationHandler<AppSpecificRequirement>
    {
        public AppSpecificHandler(IRepository repository)
        {
            Repository = repository;
        }
        public IRepository Repository { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AppSpecificRequirement requirement)
        {
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);

            if(userId == null)
                context.Fail();

            var emp = Repository.GetById<Employee>(x => x.UserId.ToLower() == userId.Value.ToLower());

            if(emp == null)
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
