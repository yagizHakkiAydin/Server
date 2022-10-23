using BattleOfMinds.API.Business;
using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCategoriesController : ControllerBase
    {
        private readonly IQuestionCategoriesBusiness _questionCategoriesBusiness;

        public QuestionCategoriesController(IQuestionCategoriesBusiness questionCategoriesBusiness)
        {
            _questionCategoriesBusiness = questionCategoriesBusiness;
        }


        [HttpGet("{id}")]
        public async Task<QuestionCategories> Get(int id)
        {
            return  await _questionCategoriesBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
        }

        [HttpGet]

        public async Task<IEnumerable<QuestionCategories>> GetAll()
        {
            return await _questionCategoriesBusiness.GetAll(o => o.isDeleted.Equals(false));
        }

        [HttpPost]
        public async Task<QuestionCategories> Add(QuestionCategories questionCategories)
        {
            return await _questionCategoriesBusiness.Add(questionCategories);
        }

        [HttpDelete]
        public async Task<QuestionCategories> Delete(int id)
        {
            var result = await _questionCategoriesBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
            result.isDeleted = true;
            return await _questionCategoriesBusiness.Update(result);
        }

        [HttpPut]
        public async Task<QuestionCategories> Update(QuestionCategories questionCategories)
        {

            return await _questionCategoriesBusiness.Update(questionCategories);
        }


    }
}
