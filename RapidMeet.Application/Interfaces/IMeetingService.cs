using RapidMeet.Application.DTOs.MeetingDTOs;

namespace RapidMeet.Application.Interfaces
{
    public interface IMeetingService
    {
        Task<MeetingResponseDTO> CreateMeetingAsync(CreateMeetingRequestDTO dto);
        Task<IEnumerable<MeetingResponseDTO>> GetAllMeetingsAsync();
        Task<MeetingResponseDTO?> GetMeetingByIdAsync(int id);
        Task<bool> DeleteMeetingAsync(int id);
    }
}
