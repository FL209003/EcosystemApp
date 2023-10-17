using AppLogic.UCInterfaces;
using EcosystemApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;
using Exceptions;
using Domain.Entities;
using System.Collections.Generic;
using AppLogic.UseCases;

namespace EcosystemApp.Controllers
{
    public class SpeciesController : Controller
    {
        public IAddSpecies AddUC { get; set; }

        public IListSpecies ListUC { get; set; }

        public IFindSpecies FindUC { get; set; }

        public IRemoveSpecies RemoveUC { get; set; }

        public IListThreats ListThreatsUC { get; set; }

        public IFindThreat FindThreatUC { get; set; }

        public IWebHostEnvironment WHE { get; set; }

        public IFindConservationBySec FindConservationBySec { get; set; }

        public IListEcosystem ListEcosystemUC { get; set; }

        public IFindEcosystem FindEcosystemUC { get; set; }
        public IFindAllNotUsedBySpecies FindAllNotUsedBySpecies { get; set; }
        public IUpdateSpecies UpdateSpeciesUC { get; set; }

        public SpeciesController(IAddSpecies addUC, IWebHostEnvironment whe, IListSpecies listUC,
            IRemoveSpecies removeUC, IFindSpecies findUC, IListThreats listThreatsUC, IFindConservationBySec findConservationBySec,
            IFindThreat findThreatUC, IListEcosystem listEcosystemUC, IFindEcosystem findEcosystemUC, IFindAllNotUsedBySpecies findAllNotUsedBySpecies, IUpdateSpecies updateSpecies)
        {
            AddUC = addUC;
            ListUC = listUC;
            WHE = whe;
            FindUC = findUC;
            RemoveUC = removeUC;
            ListThreatsUC = listThreatsUC;
            FindConservationBySec = findConservationBySec;
            FindThreatUC = findThreatUC;
            ListEcosystemUC = listEcosystemUC;
            FindEcosystemUC = findEcosystemUC;
            FindAllNotUsedBySpecies = findAllNotUsedBySpecies;
            UpdateSpeciesUC = updateSpecies;
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
            IEnumerable<Ecosystem> ecos = ListEcosystemUC.List();
            VMSpecies vm = new () { Threats = threats, IdSelectedThreats = new List<int>(), Ecosystems = ecos, IdSelectedEcos = new List<int>() };
            
            return View(vm);
        }

        // POST: SpeciesController/Create
        [Private]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSpecies(VMSpecies model)
        {
            try
            {
                if (model.Species.Threats == null) { model.Species.Threats = new List<Threat>(); };
                if(model.Species.Ecosystems == null) { model.Species.Ecosystems = new List<Ecosystem>(); };

                model.Threats = ListThreatsUC.List();
                model.Ecosystems = ListEcosystemUC.List();

                foreach (int threat in model.IdSelectedThreats) { model.Species.Threats.Add(FindThreatUC.Find(threat)); };
                foreach (int eco in model.IdSelectedEcos) { model.Species.Ecosystems.Add(FindEcosystemUC.Find(eco)); };

                model.Species.SpeciesConservation = FindConservationBySec.FindBySecutiry(model.Species.Security);
                model.Species.SpeciesName = new Domain.ValueObjects.Name(model.SpeciesNameVal);
                model.Species.SpeciesDescription = new Domain.ValueObjects.Description(model.SpeciesDescriptionVal);

                FileInfo fi = new(model.ImgSpecies.FileName);
                string ext = fi.Extension;

                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {

                    string fileName = model.Species.Id + "_001" + ext;
                    model.Species.ImgRoute = fileName;

                    string rootDir = WHE.WebRootPath;
                    string route = Path.Combine(rootDir, "img/Species", fileName);
                    using (FileStream fs = new(route, FileMode.Create))
                    {
                        model.ImgSpecies.CopyTo(fs);
                    }
                    model.Species.Validate();
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

        public ActionResult AssignEcosystem(int id)
        {
            Species species = FindUC.Find(id);
            IEnumerable<Ecosystem> ecos = FindAllNotUsedBySpecies.FindAllNotUsedBySpecies(species);
            if (species == null)
            {
                ViewBag.Error = "El cliente con el id " + id + " noexiste";
            }
            VMSpecies vm = new VMSpecies() { Species = species, Ecosystems = ecos, IdSelectedThreats = new List<int>(), };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignEcosystem(VMSpecies s, int speciesId)
        {
            try
            {
                Species species = FindUC.Find(speciesId);
                foreach (int eco in s.IdSelectedEcos) { species.Ecosystems.Add(FindEcosystemUC.Find(eco)); };
                UpdateSpeciesUC.UpdateSpecies(species);
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
            }
            
            return View();
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

        public ActionResult Delete(int id) {
            Species species = FindUC.Find(id);
            if (species == null)
            {
                ViewBag.Error = "El cliente con el id " + id + " noexiste";
            }
            return View(species);
        }

        // POST: SpeciesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Species s)
        {
            try
            {
                if (s != null)
                {
                    RemoveUC.Remove(s);
                    return RedirectToAction("Index", "Species");
                }
                else throw new InvalidOperationException("No se encontró la specie que desea eliminar.");
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
