using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ArchitectureCeA.Model;
using ArchitectureCeA.Data.Infrastructure;

namespace ArchitectureCeA.Data.Repository
{
    public class ActionPlanRepository : Infrastructure.RepositoryBase<ActionPlan>, IActionPlanRepository
    {

        public ActionPlanRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}