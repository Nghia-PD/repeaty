public static class DataSeeder
{
    public static async Task SeedTestDataAsync(RepeatyDbContext db)
    {
        if (!db.PublicUserProfiles.Any())
        {
            db.PublicUserProfiles.AddRange(new PublicUserProfile
            {
                Username = "Tester1",
                Streak = 1,
            });

            db.PublicUserProfiles.AddRange(new PublicUserProfile
            {
                Username = "Tester2",
                Streak = 13,
            });

            await db.SaveChangesAsync();
        }
    }
}