

public class PublicUserProfile
{
    public required string Id { get; set; }
    public required string Username { get; set; }
    public required int Streak { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset UpdatedAt { get; set; }
}