using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Thinktecture.IdentityModel.Http.Cors.WebAPI
{
    public static class WebAPIConfiguration
    {
        public static void ConfigureCors(this HttpConfiguration httpConfig, Action<CorsConfiguration> corsRegistrationFunction)
        {
            if (httpConfig == null) throw new ArgumentException("httpConfig");
            if (corsRegistrationFunction == null) throw new ArgumentException("corsRegistrationFunction");

            var corsConfig = new CorsConfiguration();
            corsRegistrationFunction(corsConfig);
            httpConfig.MessageHandlers.Add(new CorsMessageHandler(corsConfig, httpConfig));
        }
    }
}
