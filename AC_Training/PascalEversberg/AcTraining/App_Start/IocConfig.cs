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

            // die Reihenfolge der folgenden Zeilen ist aufgrund ihrer Abhängigkeiten empfehlenswert
            //tatsächliches singuläres Objekt
            builder.RegisterInstance(connection)
                .SingleInstance();

            //"Bauanleitung" für jede Instanz
            builder.RegisterType<DataContext>()
                .InstancePerRequest();

            //"Bauanleitung" für jede Instanz vor Refactoring
            /*builder.RegisterType<CustomerRepository>()
                .InstancePerRequest();*/

            //"Bauanleitung" für jede Instanz nach Refactoring => "Wenn jemand nach ICustomerRep fragt, dann gib ihm ein CustomerRep"
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