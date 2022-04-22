using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ZaloVidoAPI.Dtos
{
    public class FQACreateDto
    {
        public string Type { get; set; }

        [Required]
        public string Answers { get; set; }
    }
}