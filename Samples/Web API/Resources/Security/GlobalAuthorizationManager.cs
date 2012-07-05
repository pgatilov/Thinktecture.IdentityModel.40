using System.Linq;
using System.Threading;
using System.Web.Http.Controllers;
using Microsoft.IdentityModel.Claims;
using Thinktecture.IdentityModel.Authorization;
using Thinktecture.IdentityModel.Authorization.WebApi;

namespace Resources.Security
{
    public class GlobalAuthorizationManager : GlobalAuthorization
    {
        public GlobalAuthorizationManager(DefaultPolicy policy = DefaultPolicy.Deny)
            : base(policy)
        { }

        // global authorization rules
        protected override bool Default(HttpActionContext context)
        {
            var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
            var claimsId = principal.Identity as ClaimsIdentity;

            // demand a name claim
            return claimsId.Claims.Any(c => c.ClaimType == ClaimTypes.Name);
        }

        // authorization rules for consultants controller
        public bool ConsultantsAuthorization(HttpActionContext context)
        {
            return true;
        }
    }
}
