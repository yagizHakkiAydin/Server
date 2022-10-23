using BattleOfMinds.API.Business;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {

        QuestionTypeBusiness business = new QuestionTypeBusiness();

        [HttpGet("{id}")]
        public IEnumerable<QuestionType> Get(int id)
        {
            return business.Get(id);
        }

        [HttpGet]

        public IEnumerable<QuestionType> GetAll()
        {
            return business.GetAll();
        }

    }
}
