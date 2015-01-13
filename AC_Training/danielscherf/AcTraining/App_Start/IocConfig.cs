using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AcTraining.Models;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace AcTraining.App_Start
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Registers all ASP.NET MVC controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Registers all Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // All other types to register
            DbConnection connection = Effort.DbConnectionFactory.CreatePersistent("AcTraining");

            builder.RegisterInstance(connection)
                .SingleInstance();

            builder.RegisterType<DataContext>()
                .InstancePerRequest();

            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerRequest();

            // register own types here!!!
            /*
            builder.RegisterType<Listener>()
                .As<IListener>()
                .InstancePerRequest();
            */

            var container = builder.Build();

            // Set the dependency resolver for MVC
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}