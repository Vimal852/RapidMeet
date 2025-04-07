using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidMeet.Application.DTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int ReceiverUserId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }


}
