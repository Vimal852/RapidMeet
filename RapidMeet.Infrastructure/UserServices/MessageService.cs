using Microsoft.EntityFrameworkCore;
using RapidMeet.Application.DTOs;
using RapidMeet.Application.Interfaces;
using RapidMeet.Domain.Entities;
using RapidMeet.Infrastructure.Data;

public class MessageService : IMessageService
{
    private readonly ApplicationDbContext _context;

    public MessageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SendMessageAsync(MessageDTO messageDTO)
    {
        var message = new Message
        {
            ReceiverUserId = messageDTO.ReceiverUserId,
            Content = messageDTO.Content,
            SentAt = DateTime.Now
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Message>> GetMessagesForUserAsync(int userId)
    {
        return await _context.Messages
                             .Where(m => m.ReceiverUserId == userId)
                             .ToListAsync();
    }
}



