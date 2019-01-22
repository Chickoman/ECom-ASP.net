using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class ProductCategoryViewModel
    {
        public ProductCategoryViewModel()
        {
            CategoriesList = new List<CategoryListViewModel>();
        }

        public class CategoryListViewModel
        {
            public string Name { get; set; }
            public int CategoryId { get; set; }
        }

        public List<CategoryListViewModel> CategoriesList { get; set; }
    }
}