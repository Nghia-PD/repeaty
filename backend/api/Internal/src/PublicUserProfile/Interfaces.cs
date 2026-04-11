using System.Text.Json.Serialization;

internal class PublicUserProfileReqInterface
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}