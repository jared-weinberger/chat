namespace Core;

public class NewUser
{
    public required string Handle { get; set; }
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
    public required string Password { get; set; }

}
