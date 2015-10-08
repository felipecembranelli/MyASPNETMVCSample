using ArchitectureCeA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureCeA.Services.IServices
{
    public interface IEvaluationService
	{
        IEnumerable<Evaluation> GetAll();
        Evaluation GetById(int id);
        void Add(Evaluation evaluation);
        void Update(Evaluation evaluation);
        void Delete(Evaluation evaluation);
        void CreateNewEvaluation(Evaluation evaluation);
        IEnumerable<EvaluationPractice> GetEvaluationPracticesByPerspectiveId(int evaluationId, int perspectiveId);
	} 
}
