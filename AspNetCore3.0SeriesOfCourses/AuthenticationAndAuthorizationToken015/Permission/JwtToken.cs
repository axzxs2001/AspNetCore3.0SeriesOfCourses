using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationAndAuthorizationToken015.Permission
{
    public class JwtToken
    {
        public static dynamic BuildJwtToken(Claim[] claims, PermissionRequirement permissionRequirement)
        {
            var jwt = new JwtSecurityToken(
                issuer: permissionRequirement.Issuer,
                audience: permissionRequirement.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.Add(permissionRequirement.Expiration),
                signingCredentials: permissionRequirement.SigningCredentials
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new
            {
                status = true,
                access_token = encodedJwt,
                expires_in = permissionRequirement.Expiration.TotalMilliseconds,
                token_type = "Bearer"
            };
        }
    }
}
