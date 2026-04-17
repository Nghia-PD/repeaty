public static class UserPublicEndpoints
{
    public static void MapUserPublicProfileEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/user-public-profile");


        // GET

        // GET all /
        group.MapGet("/", PublicUserProfileHandler.GetAllUser);
        // GET by id /{id}
        group.MapGet("/{id}", PublicUserProfileHandler.GetUserById);
    }
}