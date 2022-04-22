using System.ComponentModel.DataAnnotations;
namespace ZaloVidoAPI.Models
{
    public class MessageDetail{
        [Key]
        [Required]        
        public int Id { get; set; }
        [Required]
        public string AppId { get; set; }

        [Required]
        public string RecipientId { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string MsgText { get; set; }
        [Required]
        public string MsgId { get; set; }
        [Required]
        public string Timestamp {get; set;}

        [Required]
        public string SenderId { get; set; }
        public SenderModel Sender {get;set;}
    }
}