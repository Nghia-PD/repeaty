using Microsoft.AspNetCore.Mvc;

public static class Json
{
    public static IResult Write(int status, object? data)
    {
        return Results.Json(data, statusCode: status);
    }
}