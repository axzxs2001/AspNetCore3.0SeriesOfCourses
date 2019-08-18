using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorizationCookio.Permission
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public List<UserPermission> UserPermissions { get; private set; }

        public string DeniedAction { get; set; }
        public PermissionRequirement(string deniedAction, List<UserPermission> userPermissions)
        {
            DeniedAction = deniedAction;
            UserPermissions = userPermissions;
        }

    }
}
