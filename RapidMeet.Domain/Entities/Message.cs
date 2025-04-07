namespace RapidMeet.Domain.Entities;

public class Message
{

        public int Id { get; set; }
        public int ReceiverUserId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        // If there's no sender, we assume the 'ReceiverUserId' is the one receiving messages
        // You can adjust this field based on your final design
    

}
