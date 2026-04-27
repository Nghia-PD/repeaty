public static class UserEndpoints
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/user");

        // GET

        // GET all /
        group.MapGet("/", UserHandler.GetAllUser);
        // GET by id /{id}
        group.MapGet("/{id}", UserHandler.GetUserById);


        // POST

        // POST create user /
        group.MapPost("/", UserHandler.CreateUser);


        // DELETE

        // DELETE by id /{id}
        group.MapDelete("/{id}", UserHandler.DeleteUser);
    }
}