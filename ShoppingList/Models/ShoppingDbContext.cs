using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }
    }
}
