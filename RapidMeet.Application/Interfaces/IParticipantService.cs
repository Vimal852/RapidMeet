using RapidMeet.Application.DTOs;

namespace RapidMeet.Application.Interfaces;

public interface IParticipantService
{
    Task<List<ParticipantDto>> GetAllAsync();
    Task<ParticipantDto?> GetByIdAsync(int id);
    Task<ParticipantDto> CreateAsync(CreateParticipantDto dto);
    Task<bool> DeleteAsync(int id);
}
