using Microsoft.AspNetCore.Mvc;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
