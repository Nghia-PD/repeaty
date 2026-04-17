internal class PublicUserProfileService(RepeatyDbContext db)
{
    internal async Task<PublicUserProfile?> GetPublicUserProfileById(string id)
    {
        return await db.PublicUserProfiles.FindAsync(id);
    }
}