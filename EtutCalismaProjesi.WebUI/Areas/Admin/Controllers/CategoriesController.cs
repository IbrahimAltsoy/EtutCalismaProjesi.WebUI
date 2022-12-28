using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;
using EtutCalismaProjesi.WebUI.ToastrMessage;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static EtutCalismaProjesi.WebUI.ToastrMessage.ToastrMessage;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _service;
        private readonly IToastNotification toastNotification;

        public CategoriesController(IService<Category> service, IToastNotification toastNotification)
        {
            _service = service;
            this.toastNotification = toastNotification;
        }
        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }
        // toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleUpdateSuccesfull(articleUpdateDTO.Title), new ToastrOptions
        //        {
        //            Title = "Başarılı"
        //       });

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(category.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });


                    await _service.AddAsync(category);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(category.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                    ModelState.AddModelError("", "Hata mesajı oluştu");
                }

            }
            return View(category);

        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _service.Update(category);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(category);
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View();
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _service.Delete(category);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
