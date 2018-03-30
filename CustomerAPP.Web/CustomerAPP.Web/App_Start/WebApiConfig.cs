using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace CustomerAPP.Web
{
    public static class WebApiConfig
    {
        public static string ControllerOnly = "ApiControllerOnly";
        public static string ControllerAndId = "ApiControllerAndIntegerId";
        public static string ControllerAction = "ApiControllerAction";
        public static string ControllerActionAndId = "ApiControllerActionActionId";

        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new BasicAuthenticationAttribute());
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            var routes = config.Routes;
            // This controller-per-type route is ideal for GetAll calls.
            // It finds the method on the controller using WebAPI conventions
            // The template has no parameters.

            routes.MapHttpRoute(
                name: ControllerOnly,
                routeTemplate: "api/{controller}"
            );


            routes.MapHttpRoute(
                name: ControllerAndId,
                routeTemplate: "api/{controller}/{id}",
                defaults: null, //defaults: new { id = RouteParameter.Optional } //,
                constraints: new { id = @"^\d+$" } // id must be all digits
            );



            routes.MapHttpRoute(
                name: ControllerAction,
                routeTemplate: "api/{controller}/{action}"
            );

            routes.MapHttpRoute(
                name: ControllerActionAndId,
                routeTemplate: "api/{controller}/{action}/{id}"
            );

        }
    }
}
