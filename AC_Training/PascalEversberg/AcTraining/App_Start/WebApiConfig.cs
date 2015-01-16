using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using AcTraining.Models;

namespace AcTraining
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
           // builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Customer>("Customers2");

            config.Routes.MapODataServiceRoute("odata","odata", builder.GetEdmModel());
        }

    }
}