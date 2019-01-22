using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ProductCategoryViewModel();
            using (var db = new ECommerceDB())
            {
                model.CategoriesList.AddRange(db.ProductCategories.Select(x => new ProductCategoryViewModel.CategoryListViewModel
                {
                    CategoryId = x.Id,
                    Name = x.Name
                }));

                return View(model);
            }
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles = "Admin,Product Manager")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new ECommerceDB())
            {
                var category = db.ProductCategories.FirstOrDefault(x => x.Id == id);
                var model = new ViewModels.ProductCategoryEditViewModel
                {
                    CategoryId = category.Id,
                    Name = category.Name



                };
                return View(model);
            }

        }
        [Authorize(Roles = "Admin,Product Manager")]
        [HttpPost]
        public ActionResult Edit(ViewModels.ProductCategoryEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.ECommerceDB())
            {
                var category = db.ProductCategories.FirstOrDefault(r => r.Id == model.CategoryId);
                category.Name = model.Name;
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }


    }
}
