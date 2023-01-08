using EtutCalismaProjesi.Data;
using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class MainController : Controller
    {
        DatabaseContext context;

        public MainController(DatabaseContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var catogories = context.Categories.Count();
            var posts = context.Posts.Count();
            var users = context.Users.Count();
            ViewData["category"] = catogories;
            ViewData["posts"] = posts;
            ViewData["users"] = users;

            return View();
        }
    }
}
