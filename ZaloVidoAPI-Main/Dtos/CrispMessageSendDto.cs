using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ZaloVidoAPI.Dtos
{
    public class CrispMessageSendDto
    {
        [Required]
        public int Id{get;set;}
        [Required]
        public string Website_Id { get; set; }
        [Required]
        public string Event { get; set; }
        [Required]
        public long Timestamp {get;set;}

        [Required]
        [JsonProperty(PropertyName = "data")]
        public Data data {get; set;}


    }
    public class Data{
        public string Website_Id { get; set; }      
        public string Type { get; set; }
        public string Origin {get;set;}
        public string Content {get;set;}
        public long Timestamp {get;set;}
        public long Fingerprint { get; set; }
        public string Session_Id { get; set; }
        public string From { get; set; }
        public bool Stamped { get; set; }

        [Required]
        [JsonProperty(PropertyName = "user")]
        public User user { get; set; }

    }

    public class User{
        public string Nickname { get; set; }
        public string User_Id {get;set;}
    }
    

}