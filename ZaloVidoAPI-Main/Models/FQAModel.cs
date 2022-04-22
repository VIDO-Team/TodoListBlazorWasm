using System.ComponentModel.DataAnnotations;
namespace ZaloVidoAPI.Models
{
    public class FQAModel{
        [Key]
        [Required]        
        public int Id { get; set; }
        public string Type {get;set;}
        public string Answers {get;set;}
    }
}