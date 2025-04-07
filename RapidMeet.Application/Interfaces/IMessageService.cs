using RapidMeet.Application.DTOs;
using RapidMeet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidMeet.Application.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(MessageDTO messageDTO);
        Task<IEnumerable<Message>> GetMessagesForUserAsync(int userId);
    }


}
