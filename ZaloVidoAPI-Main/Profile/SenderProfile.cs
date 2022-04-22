
using AutoMapper;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;

namespace ZaloVidoAPI.Profiles
{
    public class SenderProfile : Profile
    {
        public SenderProfile()
        {
            CreateMap<SenderCreateDto,SenderModel>();
            CreateMap<SenderModel,SenderReadDto>();
            CreateMap<MessageCreateDto,SenderCreateDto>().ForMember(dest=>dest.Id,act=>act.MapFrom(src=>src.sender.id));
        }
    }
}