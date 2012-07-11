using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Web;
using System.Collections.ObjectModel;

namespace Thinktecture.IdentityModel.Web
{
    public class MachineKeySessionSecurityTokenHandler : SessionSecurityTokenHandler
    {
        public MachineKeySessionSecurityTokenHandler()
            : base(CreateTransforms())
        { }

        public MachineKeySessionSecurityTokenHandler(SecurityTokenCache cache, TimeSpan tokenLifetime)
            : base(CreateTransforms(), cache, tokenLifetime)
        { }

        private static ReadOnlyCollection<CookieTransform> CreateTransforms()
        {
            return new List<CookieTransform>
                {
                    new DeflateCookieTransform(),
                    new MachineKeyCookieTransform()
                }.AsReadOnly();
        }
    }
}
