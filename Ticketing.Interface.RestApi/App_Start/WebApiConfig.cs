using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using FiveLevelsOfMediaType;

//using FiveLevelsOfMediaType;

namespace Ticketing.Interface.RestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.AddFiveLevelsOfMediaType();
            EnableCors(config);

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void EnableCors(HttpConfiguration config)
        {
            var trustedOrigin = ConfigurationManager.AppSettings["trustedOrigin"];
            var corsAttribute=new EnableCorsAttribute(trustedOrigin,"*","*");
            config.EnableCors(corsAttribute);
        }
    }
}
