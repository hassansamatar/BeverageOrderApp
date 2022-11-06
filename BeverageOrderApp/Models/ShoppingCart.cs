using System.ComponentModel.DataAnnotations;

namespace BeverageOrderApp.Models
{
    public class ShoppingCart
    {
        public Product Product { get; set; }
        [Range(1,3, ErrorMessage ="Max of 3 beverages allowed")]
        public int Count { get; set; }

    }
}
