

using System.ComponentModel.DataAnnotations;

public class PublicUserProfile
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Username { get; set; }
    public int Streak { get; set; } = 0;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}