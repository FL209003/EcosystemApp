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

        public ActionResult Index() { return View(); }

        [Private(Rol = "Admin")]
        public IActionResult AddUser() { return View(); }

        [Private(Rol = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(VMUser model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.User.Validate();
                    if (model.VerificationPass == model.User.Password)
                    {
                        AddUC.Add(model.User);
                        return RedirectToAction("Index", "Home");
                    }
                    else throw new Exception("Las contraseñas no coinciden.");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View("AddSpecies", model);
                }
            }
            ViewBag.Error = "Especie no válida.";
            return View("AddSpecies");
        }
    }
}
