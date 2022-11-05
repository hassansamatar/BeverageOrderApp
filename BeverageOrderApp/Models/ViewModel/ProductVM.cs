using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeverageOrderApp.Models.ViewModel
{
    public class ProductVM
    {
        public Product  Product{ get; set; }
        public IEnumerable<SelectListItem> categoryList { get; set; }
        public IEnumerable<SelectListItem> beverageList { get; set; }

    }
}
