public static class UserHandler
{
    public static async Task<IResult> CreateUser(HttpRequest req, UserService service)
    {
        try
        {
            var dto = await Json.Read<CreateUser>(req);
            var res = await service.CreateUser(dto);

            return Results.Created($"/user-public-profile/{res.Id}", res);
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
}