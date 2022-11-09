using System.ComponentModel.DataAnnotations;

namespace BeverageOrderApp.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        [Range(1,3, ErrorMessage ="Max of 3 beverages allowed")]
       // public IEnumerable <Addition>  AdditionList { get; set; }
        public int Count { get; set; }


    }
}
