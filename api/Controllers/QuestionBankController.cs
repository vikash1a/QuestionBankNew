using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionBankController : ControllerBase
    {
        private readonly DataContext context;

        public QuestionBankController(DataContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult> CreateQuestionBank(CreateQuestionBankRequestDto createQuestionBankRequestDto){
            var questionBank = new QuestionBank(){
                Name = createQuestionBankRequestDto.Name,
                UserId = createQuestionBankRequestDto.UserId
            };
            context.QuestionBanks.Add(questionBank);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Object>> GetQuestionBank(int id){
            var questions = context.Questions.Where(x => x.QuestionBankId == id);
            await context.SaveChangesAsync();
            return Ok(questions);
        }
        [HttpGet]
        public async Task<ActionResult<Object>> GetQuestionBanks(int id){
            var questionBanks = context.QuestionBanks.Where(x=> x.UserId == id).ToList();
            await context.SaveChangesAsync();
            return Ok(new  {
                data = questionBanks,
                count = questionBanks.Count
            });
        }
    }
}