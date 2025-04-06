using Microsoft.EntityFrameworkCore;
using RapidMeet.Application.DTOs;
using RapidMeet.Application.Interfaces;
using RapidMeet.Domain.Entities;
using RapidMeet.Infrastructure.Data;

namespace RapidMeet.Infrastructure.Services;

public class ParticipantService : IParticipantService
{
    private readonly ApplicationDbContext _context;

    public ParticipantService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ParticipantDto>> GetAllAsync()
    {
        return await _context.Participants
            .Select(p => new ParticipantDto
            {
                Id = p.Id,
                MeetingId = p.MeetingId,
                UserId = p.UserId,
                IsHost = p.IsHost
            }).ToListAsync();
    }

    public async Task<ParticipantDto?> GetByIdAsync(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null) return null;

        return new ParticipantDto
        {
            Id = participant.Id,
            MeetingId = participant.MeetingId,
            UserId = participant.UserId,
            IsHost = participant.IsHost
        };
    }

    public async Task<ParticipantDto> CreateAsync(CreateParticipantDto dto)
    {
        var participant = new Participant
        {
            MeetingId = dto.MeetingId,
            UserId = dto.UserId,
            IsHost = dto.IsHost
        };

        _context.Participants.Add(participant);
        await _context.SaveChangesAsync();

        return new ParticipantDto
        {
            Id = participant.Id,
            MeetingId = participant.MeetingId,
            UserId = participant.UserId,
            IsHost = participant.IsHost
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null) return false;

        _context.Participants.Remove(participant);
        await _context.SaveChangesAsync();
        return true;
    }
}
