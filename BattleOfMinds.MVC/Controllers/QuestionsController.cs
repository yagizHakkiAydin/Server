using BattleOfMinds.Models.Models;
using BattleOfMinds.MVC.Communication;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.MVC.Controllers
{
    public class QuestionsController : Controller
    {

        public IServiceCommunication _serviceCommuniction;
        public QuestionsController(IServiceCommunication serviceCommuniction)
        {
            _serviceCommuniction = serviceCommuniction;
        }
        public async Task<IActionResult> Edit(int id)
        {
            Questions r = await _serviceCommuniction.GetResponseWithoutToken<Questions>("api/Questions/GetQuestion?id=" + id);

            ViewBag.Question = r;

            if (r.QuestionType == "Classical") return View("Index1");

            else return View("Index");
        }
        public async Task<IActionResult> Approve(int id)
        {
            Questions r = await _serviceCommuniction.GetResponseWithoutToken<Questions>("api/Questions/ApproveQuestion?questionId=" + id);

            return Redirect("~/Home/Correction");

        }

        public async Task<IActionResult> Reject(int id)
        {
            Questions r = await _serviceCommuniction.GetResponseWithoutToken<Questions>("api/Questions/RejectQuestion?questionId=" + id);

            return Redirect("~/Home/Correction");

        }

        [HttpPost]
        public async Task<string> UpdateQuestionMultiple(int id, string qdes, string category, string answer, string option1, string option2, string option3, string option4)
        {
            Questions question = new Questions();
            question.Id = id;
            question.QuestionAnswer = answer;
            question.QuestionDescription = qdes;
            question.QuestionCategory = category;
            question.QuestionType = "Multiple Choice";
            question.CompetitionsId = 1;
            question.Option1 = option1;
            question.Option2 = option2;
            question.Option3 = option3;
            question.Option4 = option4;
            question.isApproved = true;
            question.isDeleted = false;
            var r = await _serviceCommuniction.PostResponse<string>("api/Questions/Update", question);
            return r;

        }



        [HttpPost]
        public async Task<string> UpdateQuestionClassic(int id, string qdes, string category, string answer)
        {
            Questions question = new Questions();
            question.Id = id;
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
            question.isDeleted = false;
            var r = await _serviceCommuniction.PostResponse<string>("api/Questions/Update", question);
            return r;

        }

        



    }
}
