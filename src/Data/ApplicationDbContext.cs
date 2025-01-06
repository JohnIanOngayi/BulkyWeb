using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // Initialise a Category table called Categories
    public DbSet<Category>? Categories { get; set; }
}
