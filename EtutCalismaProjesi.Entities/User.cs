
using System.ComponentModel.DataAnnotations;


namespace EtutCalismaProjesi.Entities
{
    public class User: IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Soyadınız"), StringLength(50)]
        public string Surname { get; set; }
        [Display(Name = "Email"), StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Şifreniz"), StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreatedTime { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
    }
}
