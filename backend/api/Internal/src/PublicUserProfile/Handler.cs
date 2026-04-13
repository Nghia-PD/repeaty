internal static class PublicUserProfileHandler
{

    internal static async Task<IResult> GetById(string id, HttpRequest req, PublicUserProfileService service)
    {
        try
        {
            var data = await Json.Read<PublicUserProfileReq>(req);
            var result = await service.GetPublicUserProfileById(id);
            //return result is null ? Results.NotFound() : Results.Ok(result);
            var resData = new
            {
                data
            };
            return Json.Response(200, data);
        }
        catch (System.Exception e)
        {
            var data = new
            {
                error = e.GetType().Name,
                message = e.Message,
                stack_trace = e.StackTrace
            };
            return Json.Response(500, data);
        }

    }
}