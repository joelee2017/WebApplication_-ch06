using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_美學ch06.Models
{
    public partial class Product
    {
        [MetadataType(typeof(ProductMD))]
        public class ProductMD
        {
            [ScaffoldColumn(false)]
            public int ProductID { get; set; }
            [Required]
            [Display(Name ="產品名稱")]
            [StringLength(50)]
            public string ProductName { get; set; }
            [Required]
            public string QuantityPerUnit { get; set; }
            [Required]
            public bool Discontinued { get; set; }
        }
    }
}