using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeverageOrderApp.Models.ViewModel
{
    public class ProductVM
    {
        [ValidateNever]
        public Product  Product{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> categoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> beverageList { get; set; }

    }
}
