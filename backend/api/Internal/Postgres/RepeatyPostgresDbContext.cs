using Microsoft.EntityFrameworkCore;

public class RepeatyPostgresDbContext(DbContextOptions<RepeatyPostgresDbContext> options) : DbContext(options)
{
    public DbSet<PublicUserProfile> PublicUserProfiles { get; set; }
}