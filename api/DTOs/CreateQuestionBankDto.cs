using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class CreateQuestionBankRequestDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}