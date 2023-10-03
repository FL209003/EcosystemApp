using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;
using AppLogic.UCInterfaces;
using EcosystemApp.Models;

namespace EcosystemApp.Controllers
{
    public class UserController : Controller
    {
        public IAddUser AddUC { get; set; }

        public UserController(IAddUser addUC)
        {
            AddUC = addUC;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddUser() { return View(); }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(VMUser model)
        {  
            if (ModelState.IsValid)
            {
                try
                {
                    model.User.Validate();
                    AddUC.Add(model.User);
                    return RedirectToAction("Index","Home");
                }
                //catch (ClienteException ex)
                //{
                //    vm.Paises = CUListadoPaises.Listado();
                //    ViewBag.Error = ex.Message;
                //}
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
