using System.Text.Json;
using System.Text.Json.Serialization;

public static class Json
{
    public static async Task<T> Read<T>(HttpRequest request)
    {
        var body = await new StreamReader(request.Body).ReadToEndAsync();

        try
        {
            var data = JsonSerializer.Deserialize<T>(body, new JsonSerializerOptions
            {
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
            });

            if (data is null)
                throw new CustomExceptions.BadRequestBodyException("Request body is null or empty");

            return data;
        }
        catch (JsonException e)
        {
            throw new CustomExceptions.BadRequestBodyException(e.Message);
        }
    }
}