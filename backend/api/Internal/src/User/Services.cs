using Microsoft.EntityFrameworkCore;
using Npgsql;

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
        // create record in User

        try
        {
            var user = new UserModel
            {
                Email = dto.Email,
                Username = dto.Username,
                Streak = dto.Streak,
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user;

        }
        catch (DbUpdateException e) when (e.InnerException is PostgresException pgEx && pgEx.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            throw new CustomExceptions.ConflictException("user/email-taken", "Email already exists");
        }
        catch (Exception)
        {
            throw;
        }

        // create auth
    }
}