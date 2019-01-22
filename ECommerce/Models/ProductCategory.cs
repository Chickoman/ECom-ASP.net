using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductCategory
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }

}