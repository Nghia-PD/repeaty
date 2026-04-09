public static class UserPublicEndpoints
{
    public static void MapUserPublicProfileEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/user-public-profile");

        // Get /user-public-profile
        group.MapGet("/", async () => await PublicUserProfileHandler.GetPublicUserProfileById());
    }
}