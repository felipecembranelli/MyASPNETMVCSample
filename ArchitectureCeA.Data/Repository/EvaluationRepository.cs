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
    public class EvaluationRepository : Infrastructure.RepositoryBase<Evaluation>, IEvaluationRepository
    {

        public EvaluationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<EvaluationPractice> GetEvaluationPracticesByPerspectiveId(int evaluationId, int perspectiveId)
        {
            var perspectiveRepository = new ProcessPerspectiveRepository(base.DatabaseFactory);

            //var query = base.GetById(evaluationId).EvaluationPractice.Where(p=>p.EvaluationPracticeId in );

            var query = from p in base.GetById(evaluationId).EvaluationPractice
                          join pers in perspectiveRepository.GetAll() on p.Practice.PerspectiveId equals pers.Id
                          where pers.Id == perspectiveId
                          select p;

            return query;

        }
    }
}