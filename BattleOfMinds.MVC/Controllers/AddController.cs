using BattleOfMinds.Models.Models;
using BattleOfMinds.MVC.Communication;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.MVC.Controllers
{
    public class AddController : Controller
    {

        public IServiceCommunication _serviceCommuniction;
        public AddController(IServiceCommunication serviceCommuniction)
        {
            _serviceCommuniction = serviceCommuniction;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Index2()
        {
            return View("Index1");
        }

        [HttpPost]
        public async Task<string> AddQuestionClassic(string qdes,string category,string answer) 
        {
            Questions question = new Questions();
            question.QuestionAnswer = answer;
            question.QuestionDescription = qdes;
            question.QuestionCategory = category;
            question.QuestionType = "Classical";
            question.CompetitionsId = 1;
            question.Option1 = "string";
            question.Option2 = "string";
            question.Option3 = "string";
            question.Option4 = "string";
            question.isApproved = true;
            var r = await _serviceCommuniction.PostResponse<string>("api/Questions/Add", question);
            return r;
         
        }

        [HttpPost]
        public async Task<string> AddQuestionMultiple(string qdes, string category, string answer, string option1, string option2, string option3, string option4)
        {
            Questions question = new Questions();
            question.QuestionAnswer = answer;
            question.QuestionDescription = qdes;
            question.QuestionCategory = category;
            question.QuestionType = "Multiple Choice";
            question.CompetitionsId = 1;
            question.Option1 = option1;
            question.Option2 = option2;
            question.Option3 = option3;
            question.Option4 = option4;
            question.isApproved= true;
            var r = await _serviceCommuniction.PostResponse<string>("api/Questions/Add", question);
            return r;

        }
    


}

}
