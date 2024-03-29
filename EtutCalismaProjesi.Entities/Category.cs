﻿
using System.ComponentModel.DataAnnotations;

namespace EtutCalismaProjesi.Entities
{
    public class Category:IEntity

    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreatedTime { get; set; }
        public virtual List<Post>? Posts { get; set; } // Burada Category sınıfı ile Post sınıfı arasında 1 e çok bir ilişki kurduk
        
    }
}
