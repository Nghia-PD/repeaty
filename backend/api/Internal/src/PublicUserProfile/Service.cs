internal class PublicUserProfileService(RepeatyPostgresDbContext db)
{
    internal async Task<PublicUserProfile?> GetPublicUserProfileById(string id)
    {
        return await db.PublicUserProfiles.FindAsync(id);
    }
}