using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorizationToken015.Permission
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {

            string url = "";
            string method = "";
            if (context.Resource is RouteEndpoint)
            {
                var route = context.Resource as RouteEndpoint;
                if (route.RoutePattern.PathSegments.Count > 0)
                {
                    url = $"{route.RoutePattern.Defaults["controller"]?.ToString()?.ToLower()}/{ route.RoutePattern.Defaults["action"]?.ToString()?.ToLower()}";
                }
                else
                {
                    url = route.RoutePattern.RawText?.ToLower();
                }
            }
            else
            {
                var filter = context.Resource as AuthorizationFilterContext;
                url = filter?.HttpContext?.Request?.Path.Value?.ToLower();
                method = filter?.HttpContext?.Request.Method;
            }

            var userParmissions = requirement.UserPermissions;
            var isAuthenticated = context?.User?.Identity.IsAuthenticated;
            if (isAuthenticated.HasValue && isAuthenticated.Value)
            {
                if (userParmissions.GroupBy(g => g.Url).Where(w => w.Key.ToLower() == url).Count() > 0)
                {
                    var value = context.User.Claims.SingleOrDefault(s => s.Type == requirement.ClaimType)?.Value;
                    if (userParmissions.Where(p => p.Name == value && p.Url == url).Count() > 0)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        context.Fail();
                    }
                }
                else
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
