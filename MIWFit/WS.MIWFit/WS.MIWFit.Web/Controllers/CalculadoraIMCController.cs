using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.MIWFit.Web.Models;

namespace WS.MIWFit.Web.Controllers
{
    public class CalculadoraIMCController : Controller
    {
        // GET: CalculadoraIMCController
        public IActionResult CalculadoraIMCView()
        {

            if (HttpContext.Session.GetString("token") == null || HttpContext.Session.GetString("token") == String.Empty)
            {
                return RedirectToAction("LoginView", "Users");
            }
            return View();
        }

        public IActionResult CalculadoraIMCAction()
        {
            if (HttpContext.Session.GetString("token") == String.Empty)
            {
                return RedirectToAction("LoginView", "Users");
            }
            return RedirectToAction("ResulatadoIMCView");
        }

        public IActionResult ResultadoIMCView(ResultadoIMC resultado) {
            if (HttpContext.Session.GetString("token") == String.Empty)
            {
                return RedirectToAction("LoginView", "Users");
            }
            return View(resultado);
        }

    }
}
