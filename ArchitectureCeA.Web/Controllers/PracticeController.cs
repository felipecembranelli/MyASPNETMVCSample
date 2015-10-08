using ArchitectureCeA.Model;
using ArchitectureCeA.Services.IServices;
using ArchitectureCeA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureCeA.Web.Controllers
{
    public class PracticeController : BaseController
    {
        private readonly IPracticeService practiceService;
        private readonly IProcessPerspectiveService processPerspective;

        public PracticeController(IPracticeService practiceService, IProcessPerspectiveService processPerspective)
        {
            this.practiceService = practiceService;
            this.processPerspective = processPerspective;
        }

        // GET: Practice
        public ActionResult Index(int perspectiveId)
        {
            var processPerspective = this.processPerspective.GetById(perspectiveId);

            var practiceList = this.practiceService.GetByPerspectiveId(perspectiveId).ToList();

            var practiceViewModelList = AutoMapper.Mapper.Map<List<Practice>, List<PracticeViewModel>>(practiceList);

            ViewBag.ProcessPerspective = processPerspective;

            return View(practiceViewModelList);
        }

        // GET: Practice/Details/5
        public ActionResult Details(int id)
        {
            var practice = this.practiceService.GetById(id);

            var practiceViewModel = AutoMapper.Mapper.Map<Practice, PracticeViewModel>(practice);

            return View(practiceViewModel);
        }

        // GET: Practice/Create
        public ActionResult Create(int perspectiveId)
        {
            var practice = this.practiceService.GetById(perspectiveId);

            PracticeViewModel practiceViewModel = new PracticeViewModel();

            practiceViewModel.PerspectiveId = perspectiveId;

            ViewBag.Practice = practice;

            return View(practiceViewModel);
        }

        // POST: Practice/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PracticeViewModel practiceViewModel)
        {
            if (ModelState.IsValid)
            {

                var practiceModel = AutoMapper.Mapper.Map<PracticeViewModel, Practice>(practiceViewModel);

                this.practiceService.Add(practiceModel);

            }
            return RedirectToAction("Index", new { perspectiveId = practiceViewModel.PerspectiveId });
        }

        // GET: Practice/Edit/5
        public ActionResult Edit(int id)
        {
            var practice = this.practiceService.GetById(id);

            var practiceViewModel = AutoMapper.Mapper.Map<Practice, PracticeViewModel>(practice);

            ViewBag.Practice = practice;

            return View(practiceViewModel);
        }

        // POST: Practice/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, PracticeViewModel practiceViewModel)
        {
            if (ModelState.IsValid)
            {
                var practiceModel = AutoMapper.Mapper.Map<PracticeViewModel, Practice>(practiceViewModel);

                this.practiceService.Update(practiceModel);

                return RedirectToAction("Index", new { perspectiveId = practiceViewModel.PerspectiveId });
            }

            return View(practiceViewModel);
            
        }

        // GET: Practice/Delete/5
        public ActionResult Delete(int id)
        {
            var practice = this.practiceService.GetById(id);

            var practiceViewModel = AutoMapper.Mapper.Map<Practice, PracticeViewModel>(practice);

            return View(practiceViewModel);
        }

        // POST: Practice/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // TODO: checar FKs para deletar
            var practice = this.practiceService.GetById(id);

            var perspectiveId = practice.PerspectiveId;

            this.practiceService.Delete(practice);

            return RedirectToAction("Index", new { perspectiveId = perspectiveId });
        }
    }
}
