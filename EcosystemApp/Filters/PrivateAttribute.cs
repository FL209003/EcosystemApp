using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcosystemApp.Filters
{
    public class PrivateAttribute : ActionFilterAttribute
    {
        public string? Rol { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userName = context.HttpContext.Session.GetString("username");
            var userRol = context.HttpContext.Session.GetString("rol");

            if (!string.IsNullOrEmpty(userName))
            {
                if (string.IsNullOrEmpty(Rol)) base.OnActionExecuting(context);
                else if (Rol.Contains(userRol)) base.OnActionExecuting(context);
                else context.Result = new RedirectToActionResult("Unauthorized", "Home", null);
            }
            else
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
