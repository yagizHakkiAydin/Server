using BattleOfMinds.API.Business;
using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Models.Models;
using BattleOfMinds.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsBusiness _questionsBusiness;
        private readonly IQuestionCategoriesBusiness _questionCategoryBusiness;
        private readonly IQuestionTypeBusiness _questionTypeBusiness;
        public QuestionsController(IQuestionsBusiness questionsBusiness, IQuestionCategoriesBusiness questionCategoryBusiness, IQuestionTypeBusiness questionTypeBusiness)
        {
            _questionsBusiness = questionsBusiness;
            _questionCategoryBusiness = questionCategoryBusiness;
            _questionTypeBusiness = questionTypeBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Questions> Get(int id)
        {
            return await _questionsBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
        }

        [HttpGet]
        [Route("GetAllQuestions")]
        public async Task<IEnumerable<Questions>> GetAll()
        {
            var questions = await _questionsBusiness.GetAll(o => o.isDeleted.Equals(false));

            return questions;
        
        }
        /*
        [HttpGet]
        [Route("GetQuestions")]
        public async Task<IEnumerable<QuestionVM>> GetQuestions()
        {
            var result =new  List<QuestionVM>();

            var questions = await _questionsBusiness.GetAll(o => o.isDeleted.Equals(false));
            var questionCategory = await _questionCategoryBusiness.GetAll(o => o.isDeleted.Equals(false));
            var questionType = await _questionTypeBusiness.GetAll(o => o.isDeleted.Equals(false));


            foreach (var q in questions)
            {
                var addresult = new QuestionVM();
                addresult.QuestionId = q.Id;
                addresult.QuestionCategoryName = questionCategory.Where(o => o.Id.Equals(q.QuestionCategoryId)).FirstOrDefault().QuestionCategoryName;
                addresult.QuestionTypeName = questionType.Where(o => o.Id.Equals(q.QuestionTypeId)).FirstOrDefault().QuestionTypeName;
                addresult.Description = q.QuestionDescription;
                addresult.Answer = q.QuestionAnswer;
                addresult.Option1 = q.Option1;
                addresult.Option2 = q.Option2;
                addresult.Option3 = q.Option3;
                addresult.Option4 = q.Option4;

                result.Add(addresult);
            }


            return result;

        }

        */
        [HttpPost]
        [Route("Add")]
        public async Task<Questions> Add(Questions questions)
        {
            return await _questionsBusiness.Add(questions);
        }

        [HttpDelete]
        public async Task<Questions> Delete(int id)
        {
            var result = await _questionsBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
            result.isDeleted = true;
            return await _questionsBusiness.Update(result);
        }

        [HttpPut]
        public async Task<Questions> Update(Questions questions)
        {

            return await _questionsBusiness.Update(questions);
        }

        [HttpGet]
        [Route("ApproveQuestion")]
        public async Task<Questions> ApproveQuestion(int questionId)
        {

            var result = await _questionsBusiness.Get(o => o.Id.Equals(questionId) && o.isDeleted.Equals(false));
            result.isApproved = true;
            return await _questionsBusiness.Update(result);

        }


        [HttpGet]
        [Route("RejectQuestion")]
        public async Task<Questions> RejectQuestion(int questionId)
        {

            var result = await _questionsBusiness.Get(o => o.Id.Equals(questionId));
            return await _questionsBusiness.Remove(result);
        
        }

    }
}
