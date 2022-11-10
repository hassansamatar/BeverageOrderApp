using Microsoft.EntityFrameworkCore;
using BeverageOrderApp.Models;
namespace BeverageOrderApp.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
 
    public DbSet<Addition> Additions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet <ShoppingCart> ShoppingCarts { get; set; }
  

}
