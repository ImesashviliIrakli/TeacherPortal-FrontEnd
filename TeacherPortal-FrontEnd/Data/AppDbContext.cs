using Microsoft.EntityFrameworkCore;
using TeacherPortal_FrontEnd.Models.TeacherModels;

namespace TeacherPortal_FrontEnd.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
