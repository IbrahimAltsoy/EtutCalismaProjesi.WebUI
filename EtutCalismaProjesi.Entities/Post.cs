using System.ComponentModel.DataAnnotations;


namespace EtutCalismaProjesi.Entities
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "İçerik Açıklaması")]
        public string? Description { get; set; }

        [StringLength(150), Display(Name = "İçerik Resmi")]
        public string? Image { get; set; } = "";

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreatedTime { get; set; }
        [Display(Name = "Kategory")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategory")]
        public virtual Category? Category { get; set; }
    }
}
