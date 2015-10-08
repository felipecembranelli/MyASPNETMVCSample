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
    public class PerspectiveController : Controller
    {
        private readonly IProcessPerspectiveService processPerspectiveService;

        public PerspectiveController(IProcessPerspectiveService processPerspectiveService)
        {
            this.processPerspectiveService = processPerspectiveService;

        }

        // GET: ProcessPerspective
        public ActionResult Index()
        {
            var procList = this.processPerspectiveService.GetAll().ToList();

            var procViewModelList = AutoMapper.Mapper.Map<List<ProcessPerspective>,List<ProcessPerspectiveViewModel>>(procList);

            return View(procViewModelList);
        }

        // GET: ProcessPerspective/Details/5
        public ActionResult Details(int id)
        {

            var proc = this.processPerspectiveService.GetById(id);

            var procViewModel = AutoMapper.Mapper.Map<ProcessPerspective, ProcessPerspectiveViewModel>(proc);

            return View(procViewModel);
        }

        // GET: ProcessPerspective/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcessPerspective/Create
        [HttpPost]
        public ActionResult Create(ProcessPerspectiveViewModel processPerspective)
        {
            if (ModelState.IsValid)
            {

                var procModel = AutoMapper.Mapper.Map<ProcessPerspectiveViewModel, ProcessPerspective>(processPerspective);

                this.processPerspectiveService.Add(procModel);

            }
            return RedirectToAction("Index");
        }

        // GET: ProcessPerspective/Edit/5
        public ActionResult Edit(int id)
        {
            var proc = this.processPerspectiveService.GetById(id);

            var procViewModel = AutoMapper.Mapper.Map<ProcessPerspective, ProcessPerspectiveViewModel>(proc);

            return View(procViewModel);

        }

        // POST: ProcessPerspective/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProcessPerspectiveViewModel processPerspective)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var procModel = AutoMapper.Mapper.Map<ProcessPerspectiveViewModel, ProcessPerspective>(processPerspective);

                    this.processPerspectiveService.Update(procModel);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcessPerspective/Delete/5
        public ActionResult DeleteById(int id)
        {
            var proc = this.processPerspectiveService.GetById(id);

            var procViewModel = AutoMapper.Mapper.Map<ProcessPerspective, ProcessPerspectiveViewModel>(proc);

            return View("Delete", procViewModel);
        }

        // POST: ProcessPerspective/Delete/5
         [HttpPost, ActionName("DeleteById")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var procModel = this.processPerspectiveService.GetById(id);

                this.processPerspectiveService.Delete(procModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
