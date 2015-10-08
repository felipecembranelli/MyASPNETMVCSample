using ArchitectureCeA.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchitectureCeA.Web.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {

            // Configure AutoMapper (Entity Mapper)
            AutoMapperConfiguration.Configure();

            // IOC configuration
            AutoFacConfig.ConfigureContainer();
        }
    }
}