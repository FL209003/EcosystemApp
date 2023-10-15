using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;
using AppLogic.UCInterfaces;
using EcosystemApp.Models;

namespace EcosystemApp.Controllers
{
    [Private(Role = "Admin")]
    public class UserController : Controller
    {
        public IAddUser AddUC { get; set; }

        public UserController(IAddUser addUC)
        {
            AddUC = addUC;
        }

        public ActionResult Index() { return View(); }

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
                    if (model.VerificationPass == model.User.Password)
                    {
                        AddUC.Add(model.User);
                        return RedirectToAction("Index", "Home");
                    }
                    else throw new InvalidOperationException("Las contraseñas no coinciden.");
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
            ViewBag.Error = "Especie no válida.";
            return View(model);
        }
    }
}
