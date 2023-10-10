using AppLogic.UCInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;

namespace EcosystemApp.Controllers
{
    public class EcosystemController : Controller
    {        
        public IAddEcosystem AddUC { get; set; }
        public IRemoveEcosystem RemoveUC { get; set; }
        public IListEcosystem ListUC { get; set; }
        public IFindEcosystem FindUC { get; set; }

        public EcosystemController(IAddEcosystem addUC, IRemoveEcosystem removeUC, IListEcosystem listUC, IFindEcosystem findUC)
        {            
            AddUC = addUC;
            RemoveUC = removeUC;
            ListUC = listUC;
            FindUC = findUC;
        }
        
        public ActionResult Index() { return View(); }
        
        public ActionResult ListEcosystems() 
        {
            IEnumerable<Ecosystem> ecos = ListUC.List(); 
            if (ecos != null) {
                return View(ecos);
            } else {
                ViewBag.Error = "No se encontraron ecosistemas.";
                return RedirectToAction("ListEcos", "Ecosystem", new { error = ViewBag.Error });
            }
        }      
                
        [Private]
        public ActionResult AddEcosystem() { return View(); }

        // POST: EcosystemController/Create
        [Private]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEcosystem(VMEcosystem model)
        {
            model.Ecosystem.EcosystemName = new Domain.ValueObjects.Name(model.EcosystemNameVAL);
            try
            {
                model.Ecosystem.Validate();
                AddUC.Add(model.Ecosystem);                
                return RedirectToAction("AddEcosystem", "Ecosystem");
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }     
                
        // POST: EcosystemController/Delete
        [Private]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var e = FindUC.Find(id);            
            try 
            {    
                if (e != null) {                
                    RemoveUC.Remove(e);
                    return RedirectToAction("Delete", "Ecosystem");
                } else throw InvalidOperationException("No se encontró el ecosistema que desea borrar.");
            }
            catch (Exception ex) {
                ViewBag.Error = ex.Message;
                return View();
            }                    
        }
    }
}
