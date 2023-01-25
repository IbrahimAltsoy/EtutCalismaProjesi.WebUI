using EtutCalismaProjesi.Entities;

namespace EtutCalismaProjesi.WebUI.Models
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
