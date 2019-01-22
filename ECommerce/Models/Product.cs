using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        public string Beskrivning { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}