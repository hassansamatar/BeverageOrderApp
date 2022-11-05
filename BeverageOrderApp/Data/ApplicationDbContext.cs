using Microsoft.EntityFrameworkCore;
using BeverageOrderApp.Models;
namespace BeverageOrderApp.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Addition> Additions { get; set; }


}
