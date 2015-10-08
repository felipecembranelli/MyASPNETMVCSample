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
    public class EvaluationPracticeRepository : Infrastructure.RepositoryBase<EvaluationPractice>, IEvaluationPracticeRepository
    {

        public EvaluationPracticeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}