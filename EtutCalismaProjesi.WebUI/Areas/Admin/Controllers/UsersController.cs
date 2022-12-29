using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static EtutCalismaProjesi.WebUI.ToastrMessage.ToastrMessage;

namespace EtutCalismaProjesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class UsersController : Controller
    {
        private readonly IService<User> _service;
        private readonly IToastNotification toastNotification;

        public UsersController(IService<User> service, IToastNotification toastNotification)
        {
            _service = service;
            this.toastNotification = toastNotification;
        }
        // GET: UsersController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
            return View();
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
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
        public async Task<ActionResult> CreateAsync(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(user.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });


                    await _service.AddAsync(user);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(user.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                    ModelState.AddModelError("", "Hata mesajı oluştu");
                }

            }
            return View(user);

        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(user.Name),
                       new ToastrOptions
                       {
                           Title = "Başarılı"
                       });
                    _service.Update(user);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    toastNotification.AddErrorToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(user.Name),
                       new ToastrOptions
                       {
                           Title = "Başarısız!!!"
                       });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(user);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View();
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            var name = user.Name;
            try
            {

                _service.Delete(user);

                _service.SaveChanges();
                toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrDeleteSuccessful(name),
                       new ToastrOptions
                       {
                           Title = "Başarılı"
                       });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
