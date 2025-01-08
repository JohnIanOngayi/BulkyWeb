using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // Initialise a Category table called Categories
    public DbSet<Category>? Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Category>()
            .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1,
                },
                new Category
                {
                    Id = 2,
                    Name = "SciFi",
                    DisplayOrder = 2,
                },
                new Category
                {
                    Id = 3,
                    Name = "History",
                    DisplayOrder = 3,
                },
                new Category
                {
                    Id = 4,
                    Name = "Sports",
                    DisplayOrder = 4,
                },
                new Category
                {
                    Id = 5,
                    Name = "Arcade",
                    DisplayOrder = 5,
                }
            );
    }
}
