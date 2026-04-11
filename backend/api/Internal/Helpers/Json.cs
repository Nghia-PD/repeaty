using System.Text.Json;
using System.Text.Json.Serialization;

public static class Json
{
    public static IResult Response(int status, object? data)
    {
        return Results.Json(data, statusCode: status);
    }

    public static async Task<T> Read<T>(HttpRequest request)
    {
        var body = await new StreamReader(request.Body).ReadToEndAsync(); // Read body only
        var data = JsonSerializer.Deserialize<T>(body, new JsonSerializerOptions
        {
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        });

        if (data is null)
            throw new JsonException("Request body is null or empty");

        return data;
    }
}