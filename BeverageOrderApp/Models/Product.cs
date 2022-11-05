using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeverageOrderApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        public int BeverageTypeId { get; set; }
        [ValidateNever]
        public BeverageType BeverageType { get; set; }
       // public int AdditionId { get; set; }
       // public Addition Addition { get; set; }

    }
}
