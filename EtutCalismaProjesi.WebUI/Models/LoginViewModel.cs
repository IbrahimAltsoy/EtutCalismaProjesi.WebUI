using System.ComponentModel.DataAnnotations;

namespace EtutCalismaProjesi.WebUI.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email"), StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Şifre"), StringLength(50)]
        public string Password { get; set; }
    }
}
