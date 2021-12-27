using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class User
    {
        public int Id {get ; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<QuestionBank> QuestionBanks { get; set; }
        public int QuestionBankId { get; set; }
        public ICollection<QuestionPaper> QuestionPapers { get; set; }
    }
}