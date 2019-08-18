using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorizationToken015.Permission
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public List<UserPermission> UserPermissions { get; private set; }

        public string DeniedAction { get; set; }

        public string ClaimType { internal get; set; }

        public string LoginPath { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; }

        public SigningCredentials SigningCredentials { get; set; }


        public PermissionRequirement(string deniedAction, List<UserPermission> userPermissions,string claimType,string issuer,string audience,SigningCredentials signingCredentials, TimeSpan expiration)
        {
            ClaimType = claimType;
            Issuer = issuer;
            Audience = audience;
            SigningCredentials = signingCredentials;
            DeniedAction = deniedAction;
            UserPermissions = userPermissions;
            Expiration = expiration;
        }

    }
}
