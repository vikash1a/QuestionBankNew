using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Question
    {
        public int Id {get ; set;}
        public string QuesitonText { get; set; }
        public string Answer { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public QuestionBank QuestionBank { get; set; }
        public int QuestionBankId { get; set; }

    }
}