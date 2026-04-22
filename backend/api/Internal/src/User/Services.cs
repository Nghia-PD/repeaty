using Microsoft.EntityFrameworkCore;

public class UserService(RepeatyDbContext db)
{
    public async Task<UserModel?> GetById(Guid id)
    {
        return await db.Users.FindAsync(id);
    }

    public async Task<List<UserModel>> GetAll()
    {
        return await db.Users.ToListAsync();
    }

    public async Task<UserModel> CreateUser(CreateUser dto)
    {
        // check if user exist with email

        // create record in User
        var user = new UserModel
        {
            Email = dto.Email,
            Username = dto.Username,
            Streak = dto.Streak,
        };
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();

        // create auth

        return user;
    }
}