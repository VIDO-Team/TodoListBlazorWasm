
namespace ZaloVidoAPI.Dtos
{
    public class CrispMessageReadDto
    {
        public string Website_Id { get; set; }
        public string Session_Id { get; set; }
        public string Event { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string From {get; set;}
        public string Origin {get; set;}
        public string Nickname {get; set;}
        public string User_Id {get; set;}
        public long Timestamp { get; set; }
        public bool Stamped {get; set;}
        public long Fingerprint {get; set;}

    }
}