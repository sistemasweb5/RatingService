using Microsoft.EntityFrameworkCore;

using RatingService.DataAccess.Entities;

namespace RatingService.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Rating> Ratings { get; set; }
    
}
