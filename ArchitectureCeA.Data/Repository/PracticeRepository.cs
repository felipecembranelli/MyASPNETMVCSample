﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ArchitectureCeA.Model;
using ArchitectureCeA.Data.Infrastructure;

namespace ArchitectureCeA.Data.Repository
{
    public class PracticeRepository : Infrastructure.RepositoryBase<Practice>, IPracticeRepository
    {

        public PracticeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<Practice> GetByPerspectiveId(int perspectiveId)
        {
            return base.GetAll().Where(p => p.PerspectiveId == perspectiveId);
        }
    }
}