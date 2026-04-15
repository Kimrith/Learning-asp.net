using Learning.DTOs;
using Learning.Models;
using Microsoft.EntityFrameworkCore;

namespace Learning.Data
{
    public class LearningDbContext : DbContext // Fixed: Uppercase 'C'
    {
        public LearningDbContext(DbContextOptions<LearningDbContext> options) : base(options)
        {
        }

        public DbSet<AuthUser> Auths { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}