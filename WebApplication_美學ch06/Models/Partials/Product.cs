using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Models
{
    [MetadataType(typeof(ProductMD))]
    public partial class Product
    {
        
        public class ProductMD
        {
            [ScaffoldColumn(false)]
            public int ProductID { get; set; }
            [Required(
                ErrorMessageResourceType = typeof(ModelResource),
                ErrorMessageResourceName = "ProductName")]
            [Display(Name ="產品名稱")]            
            [CustomValidation(typeof(StringValidator),"Invalid")]
            public string ProductName { get; set; }
            [Required]
            public string QuantityPerUnit { get; set; }
            [Required]
            public bool Discontinued { get; set; }        
            [Price(MinPrice = 10)]
            [Remote("Price", "Validations")]
            public Nullable<decimal> UnitPrice { get; set; }
        }

        public class StringValidator
        {
            public static ValidationResult Invalid(String productName, ValidationContext validationContext)
            {
                Regex regex = new Regex(@"[^\w\.-]", RegexOptions.IgnoreCase);
                return (productName != null && regex.Match(productName).Length > 0)
                    ? new ValidationResult("只許包含英數字元，句號(.)，連字號(-)。")
                    : ValidationResult.Success;
            }
        }
    }
}