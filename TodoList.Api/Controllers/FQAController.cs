using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZaloVidoAPI.Data;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Controllers
{           
    [Route("api/[controller]")]
    [ApiController]
    public class FQAController : ControllerBase
    {
        private readonly ZaloVidoDbContext _context;
        private readonly IMapper _mapper;

        public IMapper Mapper => _mapper;

        public FQAController(ZaloVidoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{question}", Name = "GetAnswerByQuestion")]
        public ActionResult GetFlightDetailsByCode(string question)
        {
            Console.WriteLine("GetAnswerByQuestion: {0}",question);
            Console.WriteLine("GetAnswerByQuestion:1{0}",question);
            var flight = _context.FQADetails.Where(s=>s.Question==question).Include(s=>s.FQA).FirstOrDefault();

            if (flight == null)
            {
                return NotFound();
            }
            //This mapping won't work as I have not done the Profiles section Duh!!!
            return Ok(flight.FQA.Answers);
        }


        [HttpPost]
        public ActionResult CreateQuestion(FQADetailCreateDto messageCreateDto)
        {
           var subscription = _context.FQADetails.FirstOrDefault(s => s.Question == messageCreateDto.Question);
           if (subscription == null)
           {
               subscription = Mapper.Map<FQADetailModel>(messageCreateDto);
               try
               {
                   _context.FQADetails.Add(subscription);
                   _context.SaveChanges();
               }
               catch(Exception ex)
               {
                   return BadRequest(ex.Message);
               }
               return Ok();
           }
           else
           {
               return NoContent();
           }
        }
        
    }
}