using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModels
{
    public class ProductViewModel

    {
        public string SearchProduct { get; set; }
        public string SearchDescription { get; set; }

        public ProductViewModel()
        {
            ProductList = new List<ProductListViewModel>();
        }

        public class ProductListViewModel
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public int Id { get; set; }
        }

        public string Search { get; set; }
        public string CategoryName { get; set; }
        public List<ProductListViewModel> ProductList { get; set; }
        public string CurrentSort { get; set; }


    }
}