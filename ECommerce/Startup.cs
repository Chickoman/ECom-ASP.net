﻿using ECommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerce.Startup))]
namespace ECommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Product Manager";
                roleManager.Create(role);





                //Here we create a Admin super user who will maintain the website                  
                var user = new ApplicationUser();
                user.UserName = "stefan.holmberg@nackademin.se";
                user.Email = "stefan.holmberg@nackademin.se";
                string userPWD = "Hejsan123#";
                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                    UserManager.AddToRole(user.Id, "Admin");

             
            }
         
        }
    }
}
