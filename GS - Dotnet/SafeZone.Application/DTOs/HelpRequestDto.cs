namespace SafeZone.Application.DTOs;

public class HelpRequestDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime Date { get; set; }
    public required string UserEmail { get; set; }
}
