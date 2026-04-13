using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Data
{
    public class LearningDbContext : DbContext // Fixed: Uppercase 'C'
    {
        public LearningDbContext(DbContextOptions<LearningDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<AuthsModel> Auths { get; set; }
        public DbSet<Catecory> Catecories { get; set; }
    }
}