using System.ComponentModel.DataAnnotations;

namespace BeverageOrderApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
       [Range(1,2, ErrorMessage ="Display Order must be between 1 and 2")]
        public int DisplayOrder { get; set; }
        //public DateTime OrdredDateTime { get; set; } = DateTime.Now;
    }
}
