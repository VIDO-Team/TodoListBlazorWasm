using AutoMapper;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;

namespace ZaloVidoAPI.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            //Source -> Target
            CreateMap<MessageCreateDto,MessageDetail>()
                .ForMember(dest=>dest.AppId,act=>act.MapFrom(src=>src.app_id))
                .ForMember(dest=>dest.EventName,act=>act.MapFrom(src=>src.event_name))
                .ForMember(dest=>dest.SenderId,act=>act.MapFrom(src=>src.sender.id))
                .ForMember(dest=>dest.RecipientId,act=>act.MapFrom(src=>src.recipient.id))
                .ForMember(dest=>dest.MsgId,act=>act.MapFrom(src=>src.message.msg_id))
                .ForMember(dest=>dest.MsgText,act=>act.MapFrom(src=>src.message.text))
                .ForMember(dest=>dest.Sender,act=>act.Ignore());
            CreateMap<MessageDetail,MessageReadDto>();

        }
    }
}