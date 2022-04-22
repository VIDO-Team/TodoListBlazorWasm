using System.ComponentModel.DataAnnotations;
namespace ZaloVidoAPI.Models
{
    public class CrispMessageSend{
        [Key]
        [Required]        
        public int Id {get;set;}
        [Required]   
        public string Website_Id { get; set; }
        [Required]
        public string Event { get; set; }
        [Required]
        public string Session_Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public long Timestamp {get; set;}
        [Required]
        public bool Stamped { get; set; }
        [Required]
        public long Fingerprint { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string User_Id { get; set; }
    }
}