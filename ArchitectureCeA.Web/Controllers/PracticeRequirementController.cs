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
    public class PracticeRequirementController : Controller
    {
        private readonly IPracticeRequirementService practiceRequirementService;
        private readonly IPracticeService practiceService;

        public PracticeRequirementController(IPracticeRequirementService practiceRequirementService, IPracticeService practiceService)
        {
            this.practiceRequirementService = practiceRequirementService;
            this.practiceService = practiceService;
        }

        // GET: PracticeRequirements
        public ActionResult Index(int practiceId)
        {
            var practice = this.practiceService.GetById(practiceId);

            var practiceList = this.practiceRequirementService.GetByRequirementsByPracticeId(practiceId).ToList();

            var practiceRequirementViewModelList = AutoMapper.Mapper.Map<List<PracticeRequirement>, List<PracticeRequirementViewModel>>(practiceList);

            ViewBag.Practice = practice;

            return View(practiceRequirementViewModelList);
        }

        // GET: PracticeRequirements/Details/5
        public ActionResult Details(int id)
        {
            var practice = this.practiceRequirementService.GetById(id);

            var practiceRequirementViewModel = AutoMapper.Mapper.Map<PracticeRequirement, PracticeRequirementViewModel>(practice);

            return View(practiceRequirementViewModel);
        }

        // GET: PracticeRequirements/Create
        public ActionResult Create(int practiceId)
        {
            PracticeRequirementViewModel practiceRequirementViewModel = new PracticeRequirementViewModel();

            practiceRequirementViewModel.PracticeId = practiceId;

            return View(practiceRequirementViewModel);
        }

        // POST: PracticeRequirements/Create
        [HttpPost]
        public ActionResult Create(PracticeRequirementViewModel practiceRequirementViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var practiceRequirementModel = AutoMapper.Mapper.Map<PracticeRequirementViewModel, PracticeRequirement>(practiceRequirementViewModel);

                    this.practiceRequirementService.Add(practiceRequirementModel);

                }
                return RedirectToAction("Index", new { practiceId = practiceRequirementViewModel.PracticeId });
            }
            catch
            {
                return View();
            }
        }

        // GET: PracticeRequirements/Edit/5
        public ActionResult Edit(int id)
        {
            var practice = this.practiceService.GetById(id);

            var practiceRequirement = this.practiceRequirementService.GetById(id);

            var practiceRequirementViewModel = AutoMapper.Mapper.Map<PracticeRequirement, PracticeRequirementViewModel>(practiceRequirement);

            ViewBag.Practice = practice;

            return View(practiceRequirementViewModel);
        }

        // POST: PracticeRequirements/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PracticeRequirementViewModel practiceRequirementViewModel)
        {
            if (ModelState.IsValid)
            {
                var practiceRequirementModel = AutoMapper.Mapper.Map<PracticeRequirementViewModel, PracticeRequirement>(practiceRequirementViewModel);

                this.practiceRequirementService.Update(practiceRequirementModel);

                ViewBag.PracticeId = practiceRequirementViewModel.PracticeId;

            }

            return RedirectToAction("Index", new { practiceId = practiceRequirementViewModel.PracticeId});

        }

        // GET: PracticeRequirements/Delete/5
        public ActionResult Delete(int id)
        {
            var practice = this.practiceRequirementService.GetById(id);

            var practiceRequirementViewModel = AutoMapper.Mapper.Map<PracticeRequirement, PracticeRequirementViewModel>(practice);

            return View(practiceRequirementViewModel);
        }

        // POST: PracticeRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var practice = this.practiceRequirementService.GetById(id);

            this.practiceRequirementService.Delete(practice);

            return RedirectToAction("Index", new { practiceId = id });
        }
    }
}
