using System.ComponentModel.DataAnnotations;

namespace BeverageOrderApp.Models
{
    public class Addition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

             
    
    
    }
}
