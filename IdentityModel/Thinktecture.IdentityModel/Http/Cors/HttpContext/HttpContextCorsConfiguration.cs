/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace Thinktecture.IdentityModel.Http.Cors.HttpContext
{
    public class HttpContextCorsConfiguration
    {
        static HttpContextCorsConfiguration()
        {
            Configuration = new CorsConfiguration();
        }

        public static CorsConfiguration Configuration { get; private set; }    
    }
}
