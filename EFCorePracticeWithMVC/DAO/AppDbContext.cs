using EFCorePracticeWithMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePracticeWithMVC.DAO
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        //define the Entities for database DB Sets
        public DbSet<StudentEntity> Students { get; set; }
    }
}
