using System.ComponentModel.DataAnnotations;

namespace BeverageOrderApp.Models
{
    public class BeverageType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

     

    }
}
