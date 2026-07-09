using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS.Entities;

namespace StudentManagementCQRS.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
