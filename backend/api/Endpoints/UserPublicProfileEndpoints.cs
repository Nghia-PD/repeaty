public static class UserPublicEndpoints
{
    public static void MapUserPublicProfileEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/user-public-profile");


        // user-public-profile

        // GET by id
        group.MapGet("/{id}", PublicUserProfileHandler.GetById);

    }
}