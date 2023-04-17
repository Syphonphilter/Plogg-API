namespace Plogg_API.Models
{
    public class ChatModel
    {
        public Guid Id { get; set; }
        public DateTime _userMessageTime { get; set; }
        public String userMessage { get; set; }
        public bool isSent { get; set; }
        public bool isDelivered { get; set; }
        public bool hasAttachment { get; set; }
        public bool isReply { get; set; }
        
    }
}
