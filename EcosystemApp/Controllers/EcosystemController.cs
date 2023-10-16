using AppLogic.UCInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;
using EcosystemApp.Models;
using Domain.Entities;
using Exceptions;

namespace EcosystemApp.Controllers
{
    public class EcosystemController : Controller
    {
        public IAddEcosystem AddUC { get; set; }
        public IRemoveEcosystem RemoveUC { get; set; }
        public IListEcosystem ListUC { get; set; }
        public IFindEcosystem FindUC { get; set; }
        public IWebHostEnvironment WHE { get; set; }
        public IListCountries ListCountriesUC { get; set; }

        public EcosystemController(IAddEcosystem addUC, IRemoveEcosystem removeUC, IListEcosystem listUC,
            IFindEcosystem findUC, IWebHostEnvironment whe, IListCountries listCountries)
        {
            AddUC = addUC;
            RemoveUC = removeUC;
            ListUC = listUC;
            FindUC = findUC;
            WHE = whe;
            ListCountriesUC = listCountries;
        }

        public ActionResult Index()
        {
            IEnumerable<Ecosystem> ecos = ListUC.List();
            if (ecos != null && ecos.Count() > 0)
            {

                return View(ecos);
            }
            else
            {
                ViewBag.Error = "No se encontraron ecosistemas.";
                return View(ecos);
            }
        }

        // public IActionResult Details() { return View(); }

        [Private]
        public ActionResult AddEcosystem() {
            IEnumerable<Country> countries = ListCountriesUC.List();
            VMEcosystem vmEcosystem = new VMEcosystem() { Countries = countries };
            return View(vmEcosystem);
        }

        // POST: EcosystemController/Create
        [Private]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEcosystem(VMEcosystem model)
        {

            Country c = new Country() { Id = model.IdSelectedCountry };
            

            model.Ecosystem.EcosystemName = new Domain.ValueObjects.Name(model.EcosystemNameVAL);
            model.Ecosystem.EcoDescription = new Domain.ValueObjects.Description(model.EcoDescriptionVAL);
            model.Ecosystem.GeoDetails = model.Lat + model.Long;
            model.Ecosystem.Countries = new List<Country>();
            model.Ecosystem.Countries.Add(c);
            try
            {
                FileInfo fi = new(model.ImgEco.FileName);
                string ext = fi.Extension;

                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    string fileName = model.Ecosystem.Id + ext;
                    model.Ecosystem.ImgRoute = fileName;

                    string rootDir = WHE.WebRootPath;
                    string route = Path.Combine(rootDir, "img/Ecosystems", fileName);
                    FileStream fs = new(route, FileMode.Create);

                    model.ImgEco.CopyTo(fs);
                    model.Ecosystem.Validate();
                    AddUC.Add(model.Ecosystem);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "El tipo de imagen debe ser png, jpg o jpeg.";
                    ModelState.AddModelError(string.Empty, ViewBag.Error);
                    return View(model);
                }
            }
            catch (EcosystemException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        public ActionResult DeleteConfirmation(int id) { return View(id); }

        // POST: EcosystemController/Delete
        [Private]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var e = FindUC.Find(id);
            try
            {
                if (e != null)
                {
                    RemoveUC.Remove(e);
                    return RedirectToAction("Delete", "Ecosystem");
                }
                else throw new InvalidOperationException("No se encontró el ecosistema que desea borrar.");
            }
            catch (EcosystemException ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View();
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ViewBag.Error = ex.Message);
                return View();
            }
        }
    }
}
