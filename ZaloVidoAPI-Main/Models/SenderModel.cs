using System.ComponentModel.DataAnnotations;
namespace ZaloVidoAPI.Models
{
    public class SenderModel{
        [Key]
        [Required]        
        public string Id { get; set; }
        public string? Ten { get; set; }
        public string? Diachi { get; set; }
        public string? Sdt { get; set; }
        public string? Ngaysinh { get; set; }

        public ICollection<MessageDetail> MessageDetails {get;set;}
    }
}