using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.ViewModels;
using ECommerce.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ECommerce;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = new UserViewModel();

            using (var db = new ApplicationDbContext())
            {
                model.UserList.AddRange(db.Users.Select(x => new UserViewModel.UserListViewModel
                {
                    UserId = x.Id,
                    Email = x.Email,
                    UserName = x.UserName
                }));
                foreach (var item in model.UserList)
                {
                    item.UserRoles = UserManager.GetRoles(item.UserId).SingleOrDefault();
                }
                return View(model);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string email)
        {
            var model = new UserEditViewModel();
            var user = UserManager.FindByEmail(email);
            using (var db = new ApplicationDbContext())
            {
                model.UserId = user.Id;
                model.Email = user.Email;
                model.UserName = user.UserName;
                model.UserRoles = UserManager.GetRoles(user.Id).SingleOrDefault();
                model.UserDropDownList = new List<SelectListItem>();

                foreach (var item in db.Roles)
                {
                    model.UserDropDownList.Add(new SelectListItem { Value = item.Name, Text = item.Name });
                }

                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new ApplicationDbContext())
            {
                var user = UserManager.FindById(model.UserId);
                user.Id = model.UserId;

                UserManager.RemoveFromRole(user.Id, model.UserRoles);
                UserManager.AddToRole(user.Id, model.UserDropDownHolder);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        //[HttpGet]
        //public ActionResult GetUser()
        //{
        //    var userRoles = new List<get>();
        //    var context = new ApplicationDbContext();
        //    var userStore = new UserStore<ApplicationUser>(context);
        //    var userManager = new UserManager<ApplicationUser>(userStore);

        //    //Get all the usernames
        //    foreach (var user in userStore.Users)
        //    {
        //        var r = new RolesViewModel
        //        {
        //            UserName = user.UserName
        //        };
        //        userRoles.Add(r);
        //    }
        //    //Get all the Roles for our users
        //    foreach (var user in userRoles)
        //    {
        //        user.RoleNames = userManager.GetRoles(userStore.Users.First(s => s.UserName == user.UserName).Id);
        //    }

        //    return View(userRoles);
        //}
    }}