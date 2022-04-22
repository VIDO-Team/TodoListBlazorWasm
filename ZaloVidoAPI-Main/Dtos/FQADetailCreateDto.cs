using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ZaloVidoAPI.Dtos
{
    public class FQADetailCreateDto
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public int FqaId {get;set;}
    }

}