using AppLogic.UCInterfaces;
using EcosystemApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;
using Exceptions;
using Domain.Entities;
using System.Collections.Generic;

namespace EcosystemApp.Controllers
{
    public class SpeciesController : Controller
    {
        public IAddSpecies AddUC { get; set; }

        public IListSpecies ListUC { get; set; }

        public IFindSpecies FindUC { get; set; }

        public IRemoveSpecies RemoveUC { get; set; }

        public IListThreats ListThreatsUC { get; set; }

        public IWebHostEnvironment WHE { get; set; }

        public SpeciesController(IAddSpecies addUC, IWebHostEnvironment whe, IListSpecies listUC,
            IRemoveSpecies removeUC, IFindSpecies findUC, IListThreats listThreatsUC)
        {
            AddUC = addUC;
            ListUC = listUC;
            WHE = whe;
            FindUC = findUC;
            RemoveUC = removeUC;
            ListThreatsUC = listThreatsUC;
        }
        public ActionResult Index()
        {
            IEnumerable<Species> species = ListUC.List();
            if (species != null)
            {
                return View(species);
            }
            else
            {
                ViewBag.Error = "No se encontraron especies.";
                return RedirectToAction("Index", "Species", new { error = ViewBag.Error });
            }
        }

        // public IActionResult Details() { return View(); }

        [Private]
        public ActionResult AddSpecies()
        {
            IEnumerable<Threat> threats = ListThreatsUC.List();

            VMSpecies vm = new()
            {                
                Threats = threats
            };

            return View(vm);           
        }

        // POST: SpeciesController/Create
        [Private]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSpecies(VMSpecies model)
        {
            model.Species.SpeciesName = new Domain.ValueObjects.Name(model.SpeciesNameVal);
            model.Species.SpeciesDescription = new Domain.ValueObjects.Description(model.SpeciesDescriptionVal);

            //Threat t = new Threat() { Id = model.IdSelectedThreat };
            //model.Species.Threats.Add(t);

            try
            {
                model.Species.Validate();

                FileInfo fi = new(model.ImgSpecies.FileName);
                string ext = fi.Extension;

                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    model.Species.Validate();

                    string fileName = model.Species.Id + "_001" + ext;
                    model.Species.ImgRoute = fileName;

                    string rootDir = WHE.WebRootPath;
                    string route = Path.Combine(rootDir, "img/Species", fileName);
                    FileStream fs = new(route, FileMode.Create);

                    model.ImgSpecies.CopyTo(fs);
                    AddUC.Add(model.Species);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "El tipo de imagen debe ser png, jpg o jpeg.";
                    ModelState.AddModelError(string.Empty, ViewBag.Error);
                    return View(model);
                }
            }
            catch (SpeciesException ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View(model);
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

        public ActionResult DeleteConfirmation(int id) { return View(id); }

        // POST: SpeciesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var s = FindUC.Find(id);
            try
            {
                if (s != null)
                {
                    RemoveUC.Remove(s);
                    return RedirectToAction("Index", "Species");
                }
                else throw new InvalidOperationException("No se encontró la espcie que desea eliminar.");
            }
            catch (SpeciesException ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View("Index");
            }
        }
    }
}
