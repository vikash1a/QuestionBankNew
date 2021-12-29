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
    public class QuestionController : ControllerBase
    {
        private readonly DataContext context;

        public QuestionController(DataContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult> CreateQuestion(CreateQuestionRequestDto createQuestionRequestDto){
            var question = new Question(){
                QuestionText = createQuestionRequestDto.QuestionText,
                Answer = createQuestionRequestDto.Answer,
                OptionA = createQuestionRequestDto.OptionA,
                OptionB = createQuestionRequestDto.OptionB,
                OptionC = createQuestionRequestDto.OptionC,
                OptionD = createQuestionRequestDto.OptionD,
                QuestionBankId = createQuestionRequestDto.QuestionBankId
            };
            context.Questions.Add(question);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("{QuestionId:int}")]
        public async Task<ActionResult> UpdateQuestion(int questionId,UpdateQuestionRequestDto updateQuestionRequestDto){
            var question = context.Questions.Where(x => x.Id == questionId).FirstOrDefault();
            question.QuestionText = updateQuestionRequestDto.QuestionText;
            question.Answer = updateQuestionRequestDto.Answer;
            question.OptionA = updateQuestionRequestDto.OptionA;
            question.OptionB = updateQuestionRequestDto.OptionB;
            question.OptionC = updateQuestionRequestDto.OptionC;
            question.OptionD = updateQuestionRequestDto.OptionD;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("{QuestionId:int}")]
        public async Task<ActionResult<Object>> GetQuestion(int QuestionId){
            var Question = context.Questions.Where(x => x.Id == QuestionId);
            await context.SaveChangesAsync();
            return Ok(Question);
        }
        [HttpDelete("{QuestionId:int}")]
        public async Task<ActionResult<Object>> DeleteQuestion(int QuestionId){
            var Question = context.Questions.Where(x => x.Id == QuestionId);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}