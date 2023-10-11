using AppLogic.UCInterfaces;
using AppLogic.UseCases;
using Domain.Entities;
using EcosystemApp.Filters;
using EcosystemApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcosystemApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IListUser ListUserUC { get; set; }

        public HomeController(ILogger<HomeController> logger, IListUser listUsers)
        {
            _logger = logger;
            ListUserUC = listUsers;
        }

        public IActionResult Index() { return View(); }

        public IActionResult Login() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<User> users = ListUserUC.List();
                    foreach (User u in users)
                    {
                        if (model.Username == u.Username && model.Password == u.Password)
                        {
                            HttpContext.Session.SetString("username", u.Username);
                            HttpContext.Session.SetString("rol", u.Role);
                            return RedirectToAction("Index", "Home");
                        }
                        else throw new InvalidOperationException("El usuario no existe.");
                    }
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
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}