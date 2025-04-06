namespace RapidMeet.Domain.Entities;

public class Participant
{
    public int Id { get; set; }
    public int MeetingId { get; set; }
    public int UserId { get; set; }
    public bool IsHost { get; set; }
}
