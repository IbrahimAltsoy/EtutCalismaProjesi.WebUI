using EtutCalismaProjesi.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public string chooseAdmin = "";
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string sifre)
        {
            var kullanici = await _context.Users.FirstOrDefaultAsync(k => k.IsActive && k.Email == email && k.Password == sifre);
            if (kullanici == null)
            {
                TempData["mesaj"] = "Giriş Başarısız";

            }
            else
            {
                chooseAdmin = kullanici.Name + " ve " + kullanici.Surname;


                var haklar = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, kullanici.Email)
                };
                var kullaniciKimligi = new ClaimsIdentity(haklar, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(kullaniciKimligi);
                await HttpContext.SignInAsync(claimsPrincipal);

                return Redirect("/Admin");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdminChoose()
        {

            ViewData["mesaj"] = "ibo";

            return View();
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
