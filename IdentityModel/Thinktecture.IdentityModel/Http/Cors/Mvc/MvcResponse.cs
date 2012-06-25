/*
 * Copyright (c) Dominick Baier & Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Thinktecture.IdentityModel.Http.Cors.Mvc
{
    class MvcResponse : IHttpResponseWrapper
    {
        HttpResponseBase response;
        public MvcResponse(HttpResponseBase response)
        {
            this.response = response;

        }
        public void AddHeader(string name, string value)
        {
            response.AddHeader(name, value);
        }
    }
}
