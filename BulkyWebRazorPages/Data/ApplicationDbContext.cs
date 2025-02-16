using BulkyWebRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazorPages.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<NewCategory> NewCategories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewCategory>().HasData( 
            new NewCategory { Id = 1, Name = "Action", DisplayOrder = 1 },
            new NewCategory { Id = 2, Name = "Sci-fi", DisplayOrder = 2 },
            new NewCategory { Id = 3, Name = "Comedy", DisplayOrder = 3 });
    }
    
}