using RapidMeet.Application.DTOs.MeetingDTOs;
using RapidMeet.Application.Interfaces;
using RapidMeet.Domain.Entities;
using RapidMeet.Infrastructure.Data;
using System;

namespace RapidMeet.Infrastructure.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly ApplicationDbContext _context;

        public MeetingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MeetingResponseDTO> CreateMeetingAsync(CreateMeetingRequestDTO dto)
        {
            var meeting = new Meeting
            {
                Title = dto.Title,
                ScheduledAt = dto.ScheduledAt,
                HostUserId = dto.HostUserId
            };

            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();

            return new MeetingResponseDTO
            {
                Id = meeting.Id,
                Title = meeting.Title,
                ScheduledAt = meeting.ScheduledAt,
                HostUserId = meeting.HostUserId
            };
        }

        public async Task<IEnumerable<MeetingResponseDTO>> GetAllMeetingsAsync()
        {
            return _context.Meetings
                .Select(m => new MeetingResponseDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    ScheduledAt = m.ScheduledAt,
                    HostUserId = m.HostUserId
                })
                .ToList();
        }

        public async Task<MeetingResponseDTO?> GetMeetingByIdAsync(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null) return null;

            return new MeetingResponseDTO
            {
                Id = meeting.Id,
                Title = meeting.Title,
                ScheduledAt = meeting.ScheduledAt,
                HostUserId = meeting.HostUserId
            };
        }

        public async Task<bool> DeleteMeetingAsync(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null) return false;

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
