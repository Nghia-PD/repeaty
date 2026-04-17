using Microsoft.EntityFrameworkCore;

public class RepeatyDbContext(DbContextOptions<RepeatyDbContext> options) : DbContext(options)
{
    public DbSet<PublicUserProfile> PublicUserProfiles { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        var entries = ChangeTracker.Entries<PublicUserProfile>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedAt = DateTimeOffset.UtcNow;

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
        }

        return base.SaveChangesAsync(ct);
    }
}