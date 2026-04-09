using Microsoft.AspNetCore.Mvc;

internal static class PublicUserProfileHandler
{
    internal static async Task<IResult> GetPublicUserProfileById()
    {
        return Json.Write(200, null);
    }
}