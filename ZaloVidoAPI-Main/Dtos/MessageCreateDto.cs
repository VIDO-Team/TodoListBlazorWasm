using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ZaloVidoAPI.Dtos
{
    public class MessageCreateDto
    {
        [Required]
        public string app_id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "sender")]
        public were sender {get; set;}
        
        [Required]
        [JsonProperty(PropertyName = "recipient")]
        public Recipient recipient {get; set;}
        
        [Required]
        public string event_name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "message")]
        public Message message { get; set; }

        [Required]
        public string timestamp{get;set;}
    }
    public class were{
        public string id { get; set; }
    }

    public class Recipient{
        public string id { get; set; }
    }

    public class Message{
        public string text { get; set; }
        public string msg_id { get; set; }
    }


}