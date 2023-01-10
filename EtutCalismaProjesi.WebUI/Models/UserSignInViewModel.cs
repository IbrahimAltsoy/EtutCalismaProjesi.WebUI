using System.ComponentModel.DataAnnotations;
namespace EtutCalismaProjesi.WebUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfn kullanıcı adınızı giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
