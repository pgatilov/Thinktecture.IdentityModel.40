/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using Microsoft.IdentityModel.Claims;

namespace Thinktecture.IdentityModel
{
    public static class Principal
    {
        public static ClaimsPrincipal Anonymous
        {
            get
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "")
                    };

                var anonId = new ClaimsIdentity(claims);
                var anonPrincipal = ClaimsPrincipal.CreateFromIdentity(anonId);

                return anonPrincipal as ClaimsPrincipal;
            }
        }

        public static ClaimsPrincipal Create(string authenticationType, params Claim[] claims)
        {
            return new ClaimsPrincipal(new IClaimsIdentity[]{new ClaimsIdentity(claims, authenticationType)});
        }
    }
}
