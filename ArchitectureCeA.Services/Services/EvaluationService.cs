using ArchitectureCeA.Data.Infrastructure;
using ArchitectureCeA.Data.Repository;
using ArchitectureCeA.Model;
using ArchitectureCeA.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureCeA.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository evaluationRepository;
        private readonly IPracticeRepository practiceRepository;
        private readonly IEvaluationPracticeRepository evaluationPracticeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EvaluationService(IEvaluationRepository evaluationRepository, 
                                    IPracticeRepository practiceRepository,
                                    IEvaluationPracticeRepository evaluationPracticeRepository,
                                    IUnitOfWork unitOfWork)
        {
            
            this.evaluationRepository = evaluationRepository;
            this.practiceRepository = practiceRepository;
            this.evaluationPracticeRepository = evaluationPracticeRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Model.Evaluation> GetAll()
        {
            return this.evaluationRepository.GetAll();
        }

        public Model.Evaluation GetById(int id)
        {
            return this.evaluationRepository.GetById(id);
        }

        public void Add(Model.Evaluation Evaluation)
        {
            this.evaluationRepository.Add(Evaluation);

            this.unitOfWork.Commit();
        }

        public void Update(Model.Evaluation Evaluation)
        {
            this.evaluationRepository.Update(Evaluation);

            this.unitOfWork.Commit();
        }

        public void Delete(Model.Evaluation Evaluation)
        {
            this.evaluationRepository.Delete(Evaluation);

            this.unitOfWork.Commit();
        }

        public void CreateNewEvaluation(Model.Evaluation evaluation)
        {
            try
            {
                // Create Evaluation
                this.evaluationRepository.Add(evaluation);

                this.unitOfWork.Commit();

                var newId = evaluation.Id;

                foreach (var p in this.practiceRepository.GetAll())
                {
                    var evalPractice = new EvaluationPractice();

                    evalPractice.EvaluationId = newId;
                    evalPractice.EvaluationPracticeId = p.Id;

                    this.evaluationPracticeRepository.Add(evalPractice);
                }

                
                this.unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }

        public IEnumerable<EvaluationPractice> GetEvaluationPracticesByPerspectiveId(int evaluationId, int perspectiveId)
        {
            return this.evaluationRepository.GetEvaluationPracticesByPerspectiveId(evaluationId, perspectiveId);
        }
    }
}
