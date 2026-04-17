using Microsoft.EntityFrameworkCore;

public class PublicUserProfileService(RepeatyDbContext db)
{
    public async Task<PublicUserProfile?> GetById(Guid id)
    {
        return await db.PublicUserProfiles.FindAsync(id);
    }

    public async Task<List<PublicUserProfile>> GetAll()
    {
        return await db.PublicUserProfiles.ToListAsync();
    }
}