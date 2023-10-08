using AppLogic.UCInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcosystemApp.Controllers
{
    public class EcosystemController : Controller
    {

        public IAddEcosystem AddUC { get; set; }

        public EcosystemController(IAddEcosystem addUC)
        {
            AddUC = addUC;
        }
        // GET: EcosystemController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EcosystemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EcosystemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EcosystemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EcosystemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EcosystemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EcosystemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EcosystemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
