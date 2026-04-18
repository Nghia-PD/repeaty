using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public record CreateUser(
    [property: JsonPropertyName("username")]
    [property: Required]
    [property: StringLength(50)]
    string Username,

    [property: JsonPropertyName("email")]
    [property: Required]
    string Email,

    [property: JsonPropertyName("password")]
    [property: Required]
    string Password,

    [property: JsonPropertyName("streak")]
    int Streak = 0
);