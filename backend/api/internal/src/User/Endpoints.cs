using System.Text.RegularExpressions;

public static class UserEndpoints
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/user");


        // POST

        // POST create user
        group.MapPost("/", UserHandler.CreateUser);
    }
}