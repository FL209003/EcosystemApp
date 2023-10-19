using AppLogic.UCInterfaces;
using AppLogic.UseCases;
using EcosystemApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcosystemApp.Controllers
{
    [Private]
    public class ParamController : Controller
    {
        public IModifyLengthParam ModifyLengthParamUC { get; set; }

        public ParamController(IModifyLengthParam modifyUC)
        {
            ModifyLengthParamUC = modifyUC;
        }

        public ActionResult ModifyNameParams() { return View(); }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifyNameLengths(int minLength, int maxLength)
        {
            try
            {
                if (maxLength > minLength)
                {
                    ModifyLengthParamUC.ModifyNameParams(minLength, maxLength);
                    ViewBag.Success = "La longitud mínima y máxima del nombre se actualizó con éxito.";
                    return RedirectToAction("ModifyNameParams", new { error = ViewBag.Success });
                }
                else throw new InvalidOperationException("El largo máximo del nombre debe ser mayor al largo mínimo.");
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex;
                return RedirectToAction("ModifyNameParams", new { error = ViewBag.Error });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return RedirectToAction("ModifyNameParams", new { error = ViewBag.Error });
            }
            ViewBag.Error = "Ha ocurrido un error inesperado, intente nuevamente.";
            return RedirectToAction("ModifyNameParams", new { error = ViewBag.Error });
        }

        public ActionResult ModifyDescParams() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifyDescLengths(int minLength, int maxLength)
        {
            try
            {
                if (maxLength > minLength)
                {
                    ModifyLengthParamUC.ModifyDescParams(minLength, maxLength);
                    ViewBag.Success = "La longitud mínima y máxima de la descripción se actualizó con éxito.";
                    return RedirectToAction("ModifyDescParams", new { error = ViewBag.Success });
                }
                else throw new InvalidOperationException("El largo máximo de la descripción debe ser mayor al largo mínimo.");
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex;
                return RedirectToAction("ModifyDescParams", new { error = ViewBag.Error });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return RedirectToAction("ModifyDescParams", new { error = ViewBag.Error });
            }
            ViewBag.Error = "Ha ocurrido un error inesperado, intente nuevamente.";
            return RedirectToAction("ModifyDescParams", new { error = ViewBag.Error });
        }
    }
}
