
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;
using EtutCalismaProjesi.WebUI.Utils;
using NToastNotify;
using System.Drawing.Drawing2D;
using static EtutCalismaProjesi.WebUI.ToastrMessage.ToastrMessage;
using Microsoft.AspNetCore.Authorization;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class PostsController : Controller
    {
        private readonly IService<Post> _service;
        private readonly IService<Category> categorService;
        private readonly IToastNotification toastNotification;

        public PostsController(IService<Post> service, IService<Category> categorService, IToastNotification toastNotification)
        {
            _service = service;
            this.categorService = categorService;
            this.toastNotification = toastNotification;
        }
        // GET: PostsController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await categorService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Post post, IFormFile? Image)
        {
            if (ModelState.IsValid) // Model class ımız olan brand nesnesinin validasyon için koyduğumuz kurallarınıa (örneğin marka adı required-boş geçilemez gibi) uyulmuşsa
            {
                try
                {
                    if (Image is not null)
                    {
                        post.Image = await FileHelpers.FileLoaderAsync(Image);
                    }
                    toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(post.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                    _service.Add(post);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(post.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await categorService.GetAllAsync(), "Id", "Name");
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create2(Post post, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) post.Image = await FileHelpers.FileLoaderAsync(Image);
                    await _service.AddAsync(post);
                    await _service.SaveChangesAsync();
                    return RedirectToAction("Create", "Posts");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(post);
        }

        // GET: PostsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.CategoryId = new SelectList(await categorService.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // POST: BrandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Post post, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) post.Image = await FileHelpers.FileLoaderAsync(Image);
                    toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(post.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                    _service.Update(post);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(post.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await categorService.GetAllAsync(), "Id", "Name");
            return View(post);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View();
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Post post)
        {
            var name=post.Name;
            try
            {
                toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrDeleteSuccessful(name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                _service.Delete(post);
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
