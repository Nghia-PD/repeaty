using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

internal record GetPublicUserProfileDto(
    [property: JsonPropertyName("id")]
    [property: Required] string Id
);