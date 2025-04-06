namespace RapidMeet.Domain.Entities;

public class Message
{
    public int Id { get; set; }
    public int MeetingId { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
