using EtutCalismaProjesi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
		private readonly UserManager<AppUser> _userManager;

		public LoginController(UserManager<AppUser> userManager)
		{
			this._userManager = userManager;
		}

		public async Task<IActionResult> AdminChoose()
		{
			var model = await _userManager.FindByNameAsync(User.Identity.Name);


            ViewBag.user = "merhaba"; 
			return View();
		}
		
	}
    }
