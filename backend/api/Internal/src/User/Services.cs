using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;
using Npgsql;

public class UserService(RepeatyDbContext db, ILogger<UserService> logger)
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
        try
        {
            var user = new UserModel
            {
                Email = dto.Email,
                Username = dto.Username,
                Streak = dto.Streak,
            };
            // create record in User
            await CreateUserRecord(user);

            // create auth
            await AddUserAuth(user, dto.Password);

            await db.SaveChangesAsync();

            return user;
        }
        catch (FirebaseAuthException e)
        {
            logger.LogError("Firebase error - Code: {Code}, Message: {Message}, Inner: {Inner}",
            e.ErrorCode,
            e.Message,
            e.InnerException?.Message);

            throw;
        }
        catch (DbUpdateException e) when (e.InnerException is PostgresException pgEx && pgEx.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            // delete firebase user here?
            throw new CustomExceptions.ConflictException("user/email-taken", "Email already exists");
        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
            throw;
        }
    }

    public async Task DeleteUser(Guid id)
    {
        try
        {
            await DeleteUserAuth(id);
            await DeleteUserRecord(id);
        }
        catch (FirebaseAuthException e)
        {
            logger.LogError("Firebase error - Code: {Code}, Message: {Message}, Inner: {Inner}",
            e.ErrorCode,
            e.Message,
            e.InnerException?.Message);

            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
            throw;
        }
    }

    /* 
        Postgres operations start 
    */
    private async Task CreateUserRecord(UserModel user)
    {
        await db.Users.AddAsync(user);
    }
    private async Task DeleteUserRecord(Guid id)
    {
        await db.Users.Where(user => user.Id == id).ExecuteDeleteAsync();
    }
    /*
        Postgres operations start end 
    */


    /* 
        Firebase operations start 
    */
    private static async Task AddUserAuth(UserModel user, string pwd)
    {
        UserRecordArgs args = new UserRecordArgs
        {
            Uid = user.Id.ToString(),
            Email = user.Email,
            Password = pwd,
        };

        await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
    }

    private static async Task DeleteUserAuth(Guid id)
    {
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(id.ToString());
    }
    /* 
        Firebase operations end
    */
}