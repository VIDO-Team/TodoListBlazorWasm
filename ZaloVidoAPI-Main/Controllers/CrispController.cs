using System;
using System.Linq;
using ZaloVidoAPI.Data;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaloVidoAPI.Lib;
using System.Net.Http.Headers;
using System.Text;
namespace ZaloVidoAPI.Controllers
{           
    [Route("api/[controller]")]
    [ApiController]
    public class CrispController : ControllerBase
    {
        private readonly ZaloVidoDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        static readonly HttpClient client = new HttpClient();

        public CrispController(ZaloVidoDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost]
        public ActionResult<CrispMessageReadDto> CreateMessage(CrispMessageSendDto messageSendDto)
        {
            
                var subscription = _mapper.Map<CrispMessageSend>(messageSendDto);
                var send = new SendMessageLib(_context);

                
               
                var secretKeyOptions = new SecretKeyOption();
                _configuration.GetSection(SecretKeyOption.SecretKey).Bind(secretKeyOptions);

                try
                {
                    _context.CrispMessages.Add(subscription);
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                var messageReadDto = _mapper.Map<CrispMessageReadDto>(subscription);
                var answer = send.GetAnswerByQuestion(messageSendDto.data.Content);
                if(answer != null){
                    send.SendMessageCrisp(answer,messageSendDto.data.Website_Id,messageSendDto.data.Session_Id,secretKeyOptions.Identifer,secretKeyOptions.Key);
                }
                return Ok(messageReadDto);
           
        }


    }
}