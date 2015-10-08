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
    public class ProcessPerspectiveRepository : Infrastructure.RepositoryBase<ProcessPerspective>, IProcessPerspectiveRepository
    {

        public ProcessPerspectiveRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}