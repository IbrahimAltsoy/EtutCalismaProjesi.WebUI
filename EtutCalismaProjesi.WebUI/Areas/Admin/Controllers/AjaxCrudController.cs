using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AjaxCrudController : Controller
    {
        private readonly IService<Category> _service;

        public AjaxCrudController(IService<Category> service)
        {
            this._service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CategoryList()
        {
            var jsonCity = JsonConvert.SerializeObject(await _service.GetAllAsync());
            return Json(jsonCity);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            //category.Statu = true;
            await _service.AddAsync(category);
            await _service.SaveChangesAsync();
            var values = JsonConvert.SerializeObject(category);
            return Json(values);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var values = await _service.FindAsync(id);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var values = await _service.FindAsync(id);
            _service.Delete(values);
            await _service.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> UpdateCategory(Category category)
        {
            _service.Update(category);
            await _service.SaveChangesAsync();
            var value = JsonConvert.SerializeObject(category);


            return Json(value);
        }
    }
}
