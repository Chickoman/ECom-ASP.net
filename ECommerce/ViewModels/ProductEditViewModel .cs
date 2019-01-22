using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModels
{
    public class ProductEditViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Beskrivning { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        
    }



}
