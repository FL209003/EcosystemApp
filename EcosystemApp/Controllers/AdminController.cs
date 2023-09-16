using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;

namespace EcosystemApp.Controllers
{
    [Private(Rol = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
