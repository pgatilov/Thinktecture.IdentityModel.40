/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Thinktecture.IdentityModel.Http.Cors.IIS;

namespace Thinktecture.IdentityModel.Http.Cors.Mvc
{
    class MvcRequest : HttpContextRequest
    {
        public MvcRequest(HttpRequestBase request) 
            : base(request)
        {
        }

        public override string Resource
        {
            get { return this.request.RequestContext.RouteData.Values["controller"] as string; }
        }

        public override IDictionary<string, object> Properties
        {
            get { return this.request.RequestContext.RouteData.Values; }
        }
    }
}
