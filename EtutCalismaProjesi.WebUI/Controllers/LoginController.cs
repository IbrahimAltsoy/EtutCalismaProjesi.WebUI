using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static EtutCalismaProjesi.WebUI.ToastrMessage.ToastrMessage;

namespace EtutCalismaProjesi.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;
      
        private readonly IToastNotification toastNotification;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IToastNotification toastNotification)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel appUser)
        {
            AppUser user = new AppUser()
            {
                Name = appUser.Name,
                Surname = appUser.SurName,
                UserName = appUser.UserName,
                Email = appUser.Email,                
                ImageUrl = appUser.ImageUrl,
                PasswordHash = appUser.Password


            };

            if (appUser.Password == appUser.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(user, appUser.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }


            return View(appUser);
        }
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(UserSignInViewModel signInViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(signInViewModel.Email);
				if (user != null)
				{
					var result = await signInManager.PasswordSignInAsync(user, signInViewModel.Password, false, true);
					if (result.Succeeded)
					{

						return RedirectToAction("Index", "Main", new { Area = "Admin" });


					}
					else
					{
						toastNotification.AddErrorToastMessage(MessajeToastr.ToastrLoginUnSuccesfull(user.UserName),
					   new ToastrOptions
					   {
						   Title = "Başarısız!!!"
					   });
						ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlış girilmiştir.");
						return View();
					}
				}
				else
				{
					toastNotification.AddErrorToastMessage(MessajeToastr.ToastrLoginUnSuccesfull(user.UserName),
					   new ToastrOptions
					   {
						   Title = "Başarısız!!!"
					   });

					ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlış girilmiştir.");
					return View();
				}

			}
			else
			{
				return View();

			}

		}


	}
}
