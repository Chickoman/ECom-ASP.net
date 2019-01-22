using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private ECommerceDB db = new ECommerceDB();
        // GET: Category

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
        [Authorize(Roles = "Admin,Product Manager")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new Models.ECommerceDB())
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


            return RedirectToAction("Index","Home", new { area = "" });
        }
        [Authorize(Roles = "Admin,Product Manager")]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ECommerce.ViewModels.ProductCategoryCreateViewModel();
            return View(model);

        }
        [HttpPost]
        public ActionResult Create(ECommerce.ViewModels.ProductCategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new ECommerceDB())
            {
                var category = new Models.ProductCategory
                {
                   
                   Name = model.Name,
                  
                };
                db.ProductCategories.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home", new { area = "" });



        }



    }
}
