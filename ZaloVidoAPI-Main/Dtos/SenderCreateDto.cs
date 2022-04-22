using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ZaloVidoAPI.Dtos
{
    public class SenderCreateDto
    {
        [Required]
        public string Id {get;set;}
        public string Ten { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Ngaysinh { get; set; }
    }

}