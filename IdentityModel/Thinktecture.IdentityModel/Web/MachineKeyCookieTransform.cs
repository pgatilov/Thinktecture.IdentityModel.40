using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Web;
using System.Web.Security;

namespace Thinktecture.IdentityModel.Web
{
    public class MachineKeyCookieTransform : CookieTransform
    {
        public override byte[] Decode(byte[] encoded)
        {
            return MachineKey.Decode(Encoding.UTF8.GetString(encoded), MachineKeyProtection.All);
        }

        public override byte[] Encode(byte[] value)
        {
            return Encoding.UTF8.GetBytes(MachineKey.Encode(value, MachineKeyProtection.All));
        }
    }
}
