using AppLogic.UCInterfaces;
using EcosystemApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;

namespace EcosystemApp.Controllers
{
    public class SpeciesController : Controller
    {
        public IAddSpecies AddUC { get; set; }

        public SpeciesController(IAddSpecies addUC)
        {
            AddUC = addUC;
        }
        public ActionResult Index() { return View(); }

        // public IActionResult Details() { return View(); }

        public ActionResult AddSpecies() { return View(); }

        // POST: SpeciesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSpecies(VMSpecies model)
        {
            model.Species.SpeciesName = new Domain.ValueObjects.Name(model.SpeciesNameVAL);
            try
            {
                model.Species.Validate();
                AddUC.Add(model.Species);
                return RedirectToAction("AddSPecies", "Species");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("AddSpecies", "Species", new { error = ViewBag.Error });
            }
        }

        public ActionResult Edit(int id) { return View(id); }

        // POST: SpeciesController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpeciesController/Delete
        public ActionResult Delete(int id)
        {
            return View(id);
        }

        // POST: SpeciesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
