using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Thinktecture.IdentityModel.Tokens
{
    public interface IHttpSecurityTokenHandler
    {
        bool CanReadToken(string tokenString);
        SecurityToken ReadToken(string tokenString);
        string WriteToken(SecurityToken token);
        SecurityToken CreateToken(SecurityTokenDescriptor tokenDescriptor);

    }
}
