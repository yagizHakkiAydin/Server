using BattleOfMinds.API.Business;
using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsBusiness _questionsBusiness;

        public QuestionsController(IQuestionsBusiness questionsBusiness)
        {
            _questionsBusiness = questionsBusiness;
        }


        [HttpGet("{id}")]
        public async Task<Questions> Get(int id)
        {
            return await _questionsBusiness.Get(o => o.Id.Equals(id) && o.isDeleted.Equals(false));
        }

        [HttpGet]

        public async Task<IEnumerable<Questions>> GetAll()
        {
            return await _questionsBusiness.GetAll(o => o.isDeleted.Equals(false));
        }

        [HttpPost]
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


    }
}
