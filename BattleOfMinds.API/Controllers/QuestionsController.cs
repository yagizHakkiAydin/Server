using BattleOfMinds.API.Business;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {

        QuestionsBusiness business = new QuestionsBusiness();

        [HttpGet("{id}")]
        public IEnumerable<Questions> Get(int id)
        {
            return business.Get(id);
        }

        [HttpGet]

        public IEnumerable<Questions> GetAll()
        {
            return business.GetAll();
        }

    }
}
