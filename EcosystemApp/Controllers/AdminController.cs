using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;
using EcosystemApp.Models;

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
