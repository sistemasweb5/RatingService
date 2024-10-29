using Microsoft.EntityFrameworkCore;

namespace RatingService.DataAccess.Contexts;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
