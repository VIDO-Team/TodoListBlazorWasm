
using AutoMapper;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;

namespace ZaloVidoAPI.Profiles
{
    public class CrispProfile : Profile
    {
        public CrispProfile()
        {
            // Source -> Target
            CreateMap<CrispMessageSendDto,CrispMessageSend>()
                .ForMember(dest=>dest.Type,act=>act.MapFrom(src=>src.data.Type))
                .ForMember(dest=>dest.Website_Id,act=>act.MapFrom(src=>src.data.Website_Id))
                .ForMember(dest=>dest.Website_Id,act=>act.MapFrom(src=>src.Website_Id))
                .ForMember(dest=>dest.Origin,act=>act.MapFrom(src=>src.data.Origin))
                .ForMember(dest=>dest.Content,act=>act.MapFrom(src=>src.data.Content))
                .ForMember(dest=>dest.Timestamp,act=>act.MapFrom(src=>src.data.Timestamp))
                .ForMember(dest=>dest.Session_Id,act=>act.MapFrom(src=>src.data.Session_Id))
                .ForMember(dest=>dest.From,act=>act.MapFrom(src=>src.data.From))
                .ForMember(dest=>dest.Fingerprint,act=>act.MapFrom(src=>src.data.Fingerprint))
                .ForMember(dest=>dest.Nickname,act=>act.MapFrom(src=>src.data.user.Nickname))
                .ForMember(dest=>dest.User_Id,act=>act.MapFrom(src=>src.data.user.User_Id))
                .ForMember(dest=>dest.Stamped,act=>act.MapFrom(src=>src.data.Stamped));
            CreateMap<CrispMessageSend,CrispMessageReadDto>();
        }
    }
}