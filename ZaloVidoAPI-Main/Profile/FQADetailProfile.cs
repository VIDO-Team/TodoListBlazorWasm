
using AutoMapper;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;

namespace ZaloVidoAPI.Profiles
{
    public class FQADetailProfile : Profile
    {
        public FQADetailProfile()
        {
            CreateMap<FQADetailCreateDto,FQADetailModel>();
        }
    }
}