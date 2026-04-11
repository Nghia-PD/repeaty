internal class PublicUserProfileHandler
{
    PublicUserProfileService service;
    internal PublicUserProfileHandler(PublicUserProfileService service)
    {
        this.service = service;
    }

    internal async Task<IResult> GetById(HttpRequest req)
    {
        try
        {
            var data = await Json.Read<PublicUserProfileReqInterface>(req);

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