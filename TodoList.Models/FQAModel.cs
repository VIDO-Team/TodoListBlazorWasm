using System.ComponentModel.DataAnnotations;
namespace TodoList.Api.Models
{
    public class FQAModel{
        [Key]
        [Required]        
        public int Id { get; set; }
        public string Type {get;set;}
        public string Answers {get;set;}
    }
}