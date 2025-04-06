namespace RapidMeet.Application.DTOs.MeetingDTOs
{
    public class CreateMeetingRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public DateTime ScheduledAt { get; set; }
        public int HostUserId { get; set; }
    }

    public class MeetingResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ScheduledAt { get; set; }
        public int HostUserId { get; set; }
    }
}
