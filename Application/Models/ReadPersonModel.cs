namespace Application.Models;

public class ReadPersonModel : PersonModelBase
{
    public required Guid Id { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
}