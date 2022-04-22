
using AutoMapper;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;

namespace ZaloVidoAPI.Profiles
{
    public class FAQProfile : Profile
    {
        public FAQProfile()
        {
            CreateMap<FQACreateDto,FQAModel>();
        }
    }
}