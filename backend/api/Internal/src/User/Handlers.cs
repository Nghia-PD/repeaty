using FirebaseAdmin.Auth;

public static class UserHandler
{
    public static async Task<IResult> GetUserById(Guid id, UserService service)
    {
        try
        {
            var res = await service.GetById(id);
            return res is null ? Results.NotFound() : Results.Ok(res);
        }
        catch (FormatException e)
        {
            // when the id is not in guid format
            return Results.BadRequest(new { message = e.Message, });
        }
        catch (Exception e)
        {
            return Results.InternalServerError(new { error = e.GetType().Name, message = e.Message, });
        }
    }

    public static async Task<IResult> GetAllUser(UserService service)
    {
        try
        {
            var res = await service.GetAll();
            return Results.Ok(res);
        }
        catch (Exception e)
        {
            var data = new
            {
                error = e.GetType().Name,
                message = e.Message,
                stack_trace = e.StackTrace
            };

            return Results.InternalServerError(data);
        }
    }
    public static async Task<IResult> CreateUser(HttpRequest req, UserService service)
    {
        try
        {
            var dto = await Json.Read<CreateUser>(req);
            var res = await service.CreateUser(dto);

            return Results.Created($"/user/{res.Id}", res);
        }
        catch (CustomExceptions.BadRequestBodyException e)
        {
            return Results.BadRequest(new { message = e.Message });
        }
        catch (Exception e)
        {
            return Results.InternalServerError(new { error = e.GetType().Name, message = e.Message, });
        }
    }

    public static async Task<IResult> DeleteUser(Guid id, UserService service)
    {
        try
        {
            await service.DeleteUser(id);
            return Results.NoContent();
        }
        catch (Exception e)
        {
            return Results.InternalServerError(new { error = e.GetType().Name, message = e.Message, });
        }
    }
}