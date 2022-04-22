
namespace ZaloVidoAPI.Dtos
{
    public class MessageReadDto
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public string EventName { get; set; }
        public string MsgText { get; set; }
        public string MsgId {get; set;}
        public string Timestamp {get; set;}
    }
}