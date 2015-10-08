using ArchitectureCeA.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArchitectureCeA.Model;
using ArchitectureCeA.Web.ViewModels;

namespace ArchitectureCeA.Web.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly IEvaluationService evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            this.evaluationService = evaluationService;
        }

        // GET: Evaluation
        public ActionResult Index(int evaluationId, int perspectiveId)
        {
            return View(this.GetEvaluation(evaluationId, perspectiveId));
        }

        // GET: Evaluation
        public ActionResult GetEvaluationContent(int evaluationId, int perspectiveId, bool editMode)
        {
            if (editMode)
                return PartialView("_EditEvaluationContent", this.GetEvaluation(evaluationId, perspectiveId));
            else
                return PartialView("_ViewEvaluationContent", this.GetEvaluation(evaluationId, perspectiveId));
        }

        // GET: Evaluation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evaluation/Create
        public ActionResult Create()
        {
            var eval = new Evaluation() 
            {
                ArchitectureManager = "??",
                Project = "Project",
                ProjectSize = "M",
                Responsible = "Responsible",
                Contract = "Contract"
            };

            this.evaluationService.CreateNewEvaluation(eval);

            return RedirectToAction("Index");
        }

        // POST: Evaluation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evaluation/Edit/5
        public ActionResult Edit(int evaluationId, int perspectiveId)
        {
            return View(this.GetEvaluation(evaluationId, perspectiveId));
        }


        // POST: Evaluation/Edit/5
        [HttpPost]
        public ActionResult Edit(EvaluationVM evaluation)
        {

            Evaluation evaluationModel = this.evaluationService.GetById(evaluation.EvaluationId);

            evaluationModel.EvaluationPractice = (ICollection<EvaluationPractice>)evaluation.EvaluationPractice;

            this.evaluationService.Update(evaluationModel);

            return RedirectToAction("Index");
        }

        // GET: Evaluation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evaluation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #region Private methods

        private EvaluationVM GetEvaluation(int evaluationId, int perspectiveId) 
        {
            var evaluationPractices = this.evaluationService.GetEvaluationPracticesByPerspectiveId(evaluationId, perspectiveId);

            var evaluationPracticeVM = new EvaluationVM();

            evaluationPracticeVM.EvaluationId = evaluationId;
            evaluationPracticeVM.EvaluationPractice = evaluationPractices.ToList();
            evaluationPracticeVM.PerspectiveId = perspectiveId;
            //evaluationPracticeVM.PerspectiveName = "sdfsd";
            //evaluationPracticeVM.Requirement = evaluationPractices.SelectMany(p => p.Practice.PracticeRequirement);

            return evaluationPracticeVM;
        }

             

        #endregion
    }
}

