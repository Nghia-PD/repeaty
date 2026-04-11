public static class UserPublicEndpoints
{
    public static void MapUserPublicProfileEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/user-public-profile");


        // user-public-profile

        var PublicUserProfileService = new PublicUserProfileService();
        var PublicUserProfileHandler = new PublicUserProfileHandler(PublicUserProfileService);
        // GET by id
        group.MapGet("/", async (HttpRequest req) => await PublicUserProfileHandler.GetById(req));

    }
}