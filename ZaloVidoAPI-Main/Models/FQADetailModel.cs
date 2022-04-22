using System.ComponentModel.DataAnnotations;
namespace ZaloVidoAPI.Models
{
    public class FQADetailModel{
        [Key]
        [Required]        
        public int Id { get; set; }
        [Required]
        public int FqaId {get;set;}
        [Required]
        public FQAModel FQA {get;set;}

        [Required]
        public string Question {get;set;}
    }
}