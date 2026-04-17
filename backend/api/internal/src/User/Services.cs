public class UserService(RepeatyDbContext db)
{
    public async Task<PublicUserProfile> CreateUser(CreateUser dto)
    {
        // create Auth

        // create private profile

        // create public profile
        var user = new PublicUserProfile
        {
            Username = dto.Username,
            Streak = dto.Streak,
        };
        await db.PublicUserProfiles.AddAsync(user);
        await db.SaveChangesAsync();

        return user;
    }
}