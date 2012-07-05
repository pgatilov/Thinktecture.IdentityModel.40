using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Web.Http;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Tokens;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.Tokens.Http;

namespace Resources.Configuration
{
    public class AuthenticationConfig
    {
        public static void ConfigureGlobal(HttpConfiguration globalConfig)
        {
            globalConfig.MessageHandlers.Add(new AuthenticationHandler(CreateConfiguration()));
        }

        public static AuthenticationConfiguration CreateConfiguration()
        {
            var config = new AuthenticationConfiguration
            {
                DefaultAuthenticationScheme = "Basic",
                EnableSessionToken = true
            };

            #region BasicAuthentication
            config.AddBasicAuthentication((userName, password) => userName == password);
            #endregion

            #region SimpleWebToken
            config.AddSimpleWebToken(
                issuer: "http://identityserver.thinktecture.com/trust/initial",
                audience: Constants.Realm,
                signingKey: Constants.IdSrvSymmetricSigningKey,
                options: AuthenticationOptions.ForAuthorizationHeader("IdSrv"));
            #endregion

            #region JsonWebToken
            config.AddJsonWebToken(
                issuer: "http://selfissued.test",
                audience: Constants.Realm,
                signingKey: Constants.IdSrvSymmetricSigningKey,
                options: AuthenticationOptions.ForAuthorizationHeader("JWT"));
            #endregion

            #region IdentityServer SAML
            var idsrvRegistry = new ConfigurationBasedIssuerNameRegistry();
            idsrvRegistry.AddTrustedIssuer("a90d2bc088d949d63321e1152065234c1acda7b1", "Thinktecture IdSrv");

            var idsrvConfig = new SecurityTokenHandlerConfiguration();
            idsrvConfig.AudienceRestriction.AllowedAudienceUris.Add(new Uri(Constants.Realm));
            idsrvConfig.IssuerNameRegistry = idsrvRegistry;
            idsrvConfig.CertificateValidator = X509CertificateValidator.None;

            config.AddSaml2(idsrvConfig, AuthenticationOptions.ForAuthorizationHeader("IdSrvSaml"));
            #endregion

            #region ADFS SAML
            var adfsRegistry = new ConfigurationBasedIssuerNameRegistry();
            adfsRegistry.AddTrustedIssuer("b69346347f70a9c3720218aef1822a5c97b18ca5", "ADFS");

            var adfsConfig = new SecurityTokenHandlerConfiguration();
            adfsConfig.AudienceRestriction.AllowedAudienceUris.Add(new Uri(Constants.Realm));
            adfsConfig.IssuerNameRegistry = adfsRegistry;
            adfsConfig.CertificateValidator = X509CertificateValidator.None;

            config.AddSaml2(adfsConfig, AuthenticationOptions.ForAuthorizationHeader("AdfsSaml"));
            #endregion

            #region ACS SWT
            config.AddSimpleWebToken(
                issuer: "https://" + Constants.ACS + "/",
                audience: Constants.Realm,
                signingKey: Constants.AcsSymmetricSigningKey,
                options: AuthenticationOptions.ForAuthorizationHeader("ACS"));
            #endregion

            #region AccessKey
            config.AddAccessKey(token =>
            {
                if (ObfuscatingComparer.IsEqual(token, "accesskey123"))
                {
                    return Principal.Create("Custom",
                        new Claim("customerid", "123"),
                        new Claim("email", "foo@customer.com"));
                }

                return null;
            }, AuthenticationOptions.ForQueryString("key"));
            #endregion

            return config;
        }
    }
}
