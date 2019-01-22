using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECommerce.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            UserList = new List<UserListViewModel>();
        }

        public class UserListViewModel
        {
            public string UserId { get; set; }
            public string UserRoles { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }

        public string UserRoles { get; set; }
        public List<UserListViewModel> UserList { get; set; }
    }
}