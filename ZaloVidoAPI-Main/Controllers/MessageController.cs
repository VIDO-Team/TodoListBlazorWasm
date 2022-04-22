using System;
using System.Linq;
using ZaloVidoAPI.Data;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZaloVidoAPI.Lib;
using Microsoft.EntityFrameworkCore;

namespace ZaloVidoAPI.Controllers
{           
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ZaloVidoDbContext _context;
        private readonly IMapper _mapper;

        public MessageController(ZaloVidoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<MessageReadDto> GetMessageByMessageId()
        {
            var send = new SendMessageLib(_context);
            var subscription=send.getMessageHistory(5723854775646043503);
            if (subscription == null)
            {
                return NotFound(); 
            }

            return Ok(subscription["data"].ToString());
        }

        [HttpPost]
        public ActionResult<MessageReadDto> CreateMessage(MessageCreateDto messageCreateDto)
        {
           var subscription = _context.Messages.FirstOrDefault(s => s.MsgId == messageCreateDto.message.msg_id);
           var send = new SendMessageLib(_context);
           try
           {
               CreateSender(messageCreateDto,send.getMessageType(messageCreateDto.sender.id));
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
                return Ok();
           }
           if (subscription == null)
           {
                subscription = _mapper.Map<MessageDetail>(messageCreateDto);
                try
                {
                    _context.Messages.Add(subscription);
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                var answer = send.GetAnswerByQuestion(subscription.MsgText);
                if(answer != null){
                    send.SendMessage(subscription.SenderId,answer);
                }
                
                var messageReadDto = _mapper.Map<MessageReadDto>(subscription);

                return Ok(messageReadDto);
           }
           else
           {
               return Ok();
           }
        }
        
        private void CreateSender(MessageCreateDto messageCreateDto,string type)
        {
            var sub2 = _context.Senders.FirstOrDefault(s=>s.Id==messageCreateDto.sender.id);
            Console.WriteLine(sub2);
            if(sub2 ==null){
                var senderCreateDto = _mapper.Map<SenderCreateDto>(messageCreateDto);
                switch(type){
                    case "dc":
                        sub2.Diachi=messageCreateDto.message.text;
                        break;
                    case "sdt":
                        sub2.Sdt=messageCreateDto.message.text;
                        break;
                    case "ten":
                        sub2.Ten=messageCreateDto.message.text;
                        break;
                    case "ns":
                        sub2.Ngaysinh=messageCreateDto.message.text;
                        break;
                    default:
                        break;
                }
                sub2 = _mapper.Map<SenderModel>(senderCreateDto);
                try
                {
                    _context.Senders.Add(sub2);
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw new Exception("Exception Create Sender",ex);
                }
           }else{
                switch(type){
                    case "dc":
                        sub2.Diachi=messageCreateDto.message.text;
                        break;
                    case "sdt":
                        sub2.Sdt=messageCreateDto.message.text;
                        break;
                    case "ten":
                        sub2.Ten=messageCreateDto.message.text;
                        break;
                    case "ns":
                        sub2.Ngaysinh=messageCreateDto.message.text;
                        break;
                    default:
                        break;
                }
               try{
                   _context.SaveChanges();
               }
                catch(Exception ex)
                {
                    throw new Exception("Exception update Sender",ex);
                }
           }
        } 

        
    }
}