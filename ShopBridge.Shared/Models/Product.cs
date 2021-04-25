using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBridge.Shared.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product code is required")]
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
