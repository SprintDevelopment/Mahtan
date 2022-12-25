using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Mahtan.Data.Repositories;
using Mahtan.Assets.Extensions;
using System.Security.Claims;

namespace Mahtan.Assets.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ProfileOwnershipAuthorize : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var idRouteData = context.HttpContext.GetRouteData().Values.SingleOrDefault(v => v.Key == "id");
            if (!idRouteData.Key.IsNullOrEmpty())
            {
                var _unitOfWork = context.HttpContext.RequestServices.GetService<IUnitOfWork>();
                var personIsOwned = await _unitOfWork.People.AnyAsync(p => p.NationalCode == idRouteData.Value.ToString() && p.RelatedUserId == userId);

                if (!personIsOwned)
                    context.Result = new UnauthorizedResult();
            }
        }
    }
}
