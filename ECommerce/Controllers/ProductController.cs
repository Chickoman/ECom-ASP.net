using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Index(int id, string sort)
        {
            
            var model = new ViewModels.ProductViewModel();
            using (var db = new ECommerceDB())
            {
                model.CategoryName = string.Join("", db.ProductCategories.Where(x => x.Id == id).Select(x => x.Name));
                model.ProductList.AddRange(db.Products
                    .Select(x => new ViewModels.ProductViewModel.ProductListViewModel
                    {
                        Name = x.Name,
                        Description = x.Beskrivning,
                        Price = x.Price,
                        CategoryId = x.CategoryId,
                        ProductId = x.Id
                        
                        
                    }).Where(x => x.CategoryId == id));
                if (sort == "NamnAsc")
                    model.ProductList = model.ProductList.OrderBy(p => p.Name).ToList();
                else if (sort == "NamnDesc")
                    model.ProductList = model.ProductList.OrderByDescending(p => p.Name).ToList();


                if (sort == "PriceAsc")
                    model.ProductList = model.ProductList.OrderBy(p => p.Price).ToList();
                else if (sort == "PriceDesc")
                    model.ProductList = model.ProductList.OrderByDescending(p => p.Price).ToList();


                model.CurrentSort = sort;
                return View(model);
            }
        }
        public ActionResult Info(int id)
        {
            
           
            using (var db = new ECommerceDB())
            {
                var product = db.Products.FirstOrDefault(r => r.Id == id);
                var productmodel = new ViewModels.ProductInfoViewModel
                {
                    Name = product.Name,
                    Beskrivning = product.Beskrivning,
                    Price = product.Price,
                    Id = product.Id,
                    CategoryId = product.CategoryId,

                };

                return View(productmodel);
            }
        }



        [Authorize(Roles = "Admin,Product Manager")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new Models.ECommerceDB())
            {
                var product = db.Products.FirstOrDefault(x => x.Id == id);
                var model = new ViewModels.ProductEditViewModel
                {
                 Id = product.Id,
                 Name = product.Name,
                 Beskrivning = product.Beskrivning,
                 CategoryId = product.CategoryId,
                 Price = product.Price
                };
                return View(model);
            }
        }

        [Authorize(Roles = "Admin,Product Manager")]
        [HttpPost]
        public ActionResult Edit(ViewModels.ProductEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new Models.ECommerceDB())
            {
                var product = db.Products.FirstOrDefault(r => r.Id == model.Id);
                product.Id = model.Id;
               product.Name = model.Name;
               product.Beskrivning = model.Beskrivning;
               product.CategoryId = model.CategoryId;
               product.Price = model.Price;
              db.SaveChanges();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        [Authorize(Roles = "Admin,Product Manager")]
        [HttpGet] 
    public ActionResult Create()
        {
            var model = new ECommerce.ViewModels.ProductCreateViewModel();
            return View(model);

        }
        [Authorize(Roles = "Admin,Product Manager")]
        [HttpPost]
        public ActionResult Create(ECommerce.ViewModels.ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new ECommerceDB())
            {
                var product= new Models.Product
                {

                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    Price= model.Price,
                    Beskrivning = model.Beskrivning
                };
                db.Products.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home", new { area = "" });



        }
        [HttpGet]
        public ActionResult Search(string search, string sort)
        {
         
            var model = new ViewModels.ProductViewModel();
            using (var db = new ECommerceDB())
            {

                model.ProductList.AddRange(db.Products
                    .Select(x => new ViewModels.ProductViewModel.ProductListViewModel
                    {
                        Name = x.Name,
                        Description = x.Beskrivning,
                        Price = x.Price,
                        CategoryId = x.CategoryId,
                        ProductId = x.Id
                       


                    }).Where(x => x.Name.Contains(search) || x.Description.Contains(search)));
                if (sort == "NamnAsc")
                    model.ProductList = model.ProductList.OrderBy(p => p.Name).ToList();
                else if (sort == "NamnDesc")
                    model.ProductList = model.ProductList.OrderByDescending(p => p.Name).ToList();


                if (sort == "PriceAsc")
                    model.ProductList = model.ProductList.OrderBy(p => p.Price).ToList();
                else if (sort == "PriceDesc")
                    model.ProductList = model.ProductList.OrderByDescending(p => p.Price).ToList();
                model.Search = search;


                model.CurrentSort = sort;
                return View(model);
            }
        }
    }
    }
