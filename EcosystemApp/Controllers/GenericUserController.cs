using Microsoft.AspNetCore.Mvc;
using EcosystemApp.Filters;
using AppLogic.UCInterfaces;

namespace EcosystemApp.Controllers
{
    [Private(Rol = "GenericUser")]
    public class GenericUserController : Controller
    {
        public IAddUser AddUC { get; set; }

        public GenericUserController(IAddUser addUC)
        {
            AddUC = addUC;
        }

        public IActionResult Index()
        {
            return View();
        }        
    }
}
