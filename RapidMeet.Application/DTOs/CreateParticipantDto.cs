namespace RapidMeet.Application.DTOs;

public class CreateParticipantDto
{
    public int MeetingId { get; set; }
    public int UserId { get; set; }
    public bool IsHost { get; set; }
}
