using Asignment002.Areas.Identity.Data;
using Asignment002.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Asignment002.Policies.Handlers
{
    public class TypeHandler : AuthorizationHandler<TypeRequirememt>
    {
        private readonly UserManager<Asignment002User> _userManager;
        public TypeHandler(UserManager<Asignment002User> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TypeRequirememt requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);

            if (user != null)
            {
                var columnValue = user.GetType().GetProperty(requirement.ColumnName)?.GetValue(user, null);

                if (columnValue != null && columnValue.Equals(0)) // set 0 de cap quyen
                {
                    context.Succeed(requirement);
                    return;
                }
                
            }
            context.Fail();
        }
    }

}
