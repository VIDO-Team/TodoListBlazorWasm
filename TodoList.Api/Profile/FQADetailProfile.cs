
using AutoMapper;
using TodoList.Api.Dtos;
using TodoList.Api.Models;

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