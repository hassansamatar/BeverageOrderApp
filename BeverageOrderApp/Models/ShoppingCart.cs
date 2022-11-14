using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeverageOrderApp.Models
{
    public class ShoppingCart
    {
        [Key]

        public int Id { get; set; }

        public int  ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        [Range(1,3, ErrorMessage ="Max of 3 beverages allowed")]
         public int Count { get; set; }

       // public IEnumerable<Addition> AdditionslIst{ get; set; }


    }
}
