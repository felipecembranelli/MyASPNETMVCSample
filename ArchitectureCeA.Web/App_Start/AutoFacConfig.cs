using ArchitectureCeA.Data.Infrastructure;
using ArchitectureCeA.Data.Repository;
using ArchitectureCeA.Services;
using ArchitectureCeA.Services.IServices;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureCeA.Web.App_Start
{
    public static class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            // Configure AutoFac (IOC)

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

            // Inject Repositories
            builder.RegisterAssemblyTypes(typeof(ProcessPerspectiveRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerRequest();

            // Inject Services
            builder.RegisterType<ProcessPerspectiveService>().As<IProcessPerspectiveService>().InstancePerRequest();
            builder.RegisterType<PracticeService>().As<IPracticeService>().InstancePerRequest();
            builder.RegisterType<PracticeRequirementService>().As<IPracticeRequirementService>().InstancePerRequest();
            builder.RegisterType<EvaluationService>().As<IEvaluationService>().InstancePerRequest();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}