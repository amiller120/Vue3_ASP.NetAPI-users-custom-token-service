using fastEndpointTemplate.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace fastEndpointTemplate.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>().HasIndex(rt => new { rt.UserId, rt.Token, rt.ExpiryDate });
        }
    }
}