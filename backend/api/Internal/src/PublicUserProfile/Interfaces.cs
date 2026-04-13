using System.Text.Json.Serialization;

internal class PublicUserProfileReq
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}