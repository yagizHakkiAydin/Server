using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfMinds.Models.ViewModels
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }
        public string QuestionCategoryName { get; set; }
        public string QuestionTypeName { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

    }
}
