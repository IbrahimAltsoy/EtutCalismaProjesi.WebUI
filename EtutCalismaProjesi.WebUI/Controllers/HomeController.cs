using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;
using EtutCalismaProjesi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EtutCalismaProjesi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Category> _service;

        public HomeController(IService<Category> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
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