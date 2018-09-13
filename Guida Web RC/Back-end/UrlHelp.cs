using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Upload.Immagine
{
    public static class UrlHelp
    {
        public static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}