using CloudPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudPOS.DAO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //define the Entities for database DB Sets
     public DbSet<CategoryEntity> Categories { get; set; }
    }
}
