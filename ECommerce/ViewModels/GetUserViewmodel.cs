using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModels
{
    public class GetUserViewModel
    {
        public IEnumerable<string> RoleNames { get; set; }
        public string UserName { get; set; }
    }
}