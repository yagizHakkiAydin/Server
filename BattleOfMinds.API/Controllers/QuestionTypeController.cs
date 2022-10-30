using BattleOfMinds.API.Business;
using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {

        private readonly IQuestionTypeBusiness _questionTypeBusiness;

        public QuestionTypeController(IQuestionTypeBusiness questionTypeBusiness)
        {
            _questionTypeBusiness = questionTypeBusiness;
        }


        [HttpGet("{id}")]
        public async Task<QuestionType> Get(int id)
        {
            return await _questionTypeBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
        }

        [HttpGet]

        public async Task<IEnumerable<QuestionType>> GetAll()
        {
            return await _questionTypeBusiness.GetAll(o => o.isDeleted.Equals(false));
        }

        [HttpPost]
        public async Task<QuestionType> Add(QuestionType questionType)
        {
            return await _questionTypeBusiness.Add(questionType);
        }

        [HttpDelete]
        public async Task<QuestionType> Delete(int id)
        {
            var result = await _questionTypeBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
            result.isDeleted = true;
            return await _questionTypeBusiness.Update(result);
        }

        [HttpPut]
        public async Task<QuestionType> Update(QuestionType questionType)
        {

            return await _questionTypeBusiness.Update(questionType);
        }

    }
}
