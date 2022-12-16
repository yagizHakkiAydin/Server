using BattleOfMinds.API.Business;
using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleOfMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {

        private readonly ICompetitionBusiness _competitionsBusiness;

        public CompetitionsController(ICompetitionBusiness competitionsBusiness)
        {
            _competitionsBusiness = competitionsBusiness;
        }

        [HttpGet("{id}")]
        public async Task<Competitions> Get(int id)
        {
            return await _competitionsBusiness.Get(o => o.Id.Equals(id),o => o.currentUsers);
        }

        [HttpGet]
        public async Task<IEnumerable<Competitions>> GetAll()
        {
            return await _competitionsBusiness.GetAll(null, o => o.currentUsers, o=> o.askedQuestions);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<Competitions> Add(Competitions competititon)
        {
            return await _competitionsBusiness.Add(competititon);
        }


        [HttpPut]
        public async Task<Competitions> Update(Competitions competititon)
        {

            return await _competitionsBusiness.Update(competititon);
        }


        [HttpGet]
        [Route("findCompetition")]
        public async Task<Users> findCompetition(int userId, string GameMode)
        {

            return await _competitionsBusiness.findCompetition(userId,GameMode);

        }

        [HttpGet]
        [Route("isStarted")]
        public async Task<bool> isStarted(int competitionId)
        {

            return await _competitionsBusiness.isStarted(competitionId);

        }


        [HttpGet]
        [Route("chooseQuestion")]
        public async Task<Questions> chooseQuestion(int competitionId)
        {

            return await _competitionsBusiness.chooseQuestion(competitionId);
        
        }


        [HttpGet]
        [Route("getQuestion")]
        public async Task<Questions> getQuestion(int competitionId)
        {

            return await _competitionsBusiness.getQuestion(competitionId);
        
        }


        [HttpGet]
        [Route("exitCompetition")]
        public async Task<bool> exitCompetition(int userId)
        {

            return await _competitionsBusiness.exitCompetition(userId);
        
        }



        [HttpGet]
        [Route("decreaseCapacity")]
        public async Task<int> decreaseCapacity(int competitionId)
        {

            return await _competitionsBusiness.decreaseCapacity(competitionId);
        
        }


        [HttpPost]
        [Route("wrongAnswer")]
        public async Task<bool> wrongAnswer([FromBody] Users user)
        { 
        
            return await _competitionsBusiness.wrongAnswer(user);
        
        }


        [HttpPost]
        [Route("trueAnswer")]
        public async Task<bool> trueAnswer([FromBody] Users user)
        { 
        
            return await _competitionsBusiness.trueAnswer(user);
        
        }

        [HttpGet]
        [Route("getCurrentCapacity")]
        public async Task<int> getCurrentCapacity(int competitionId)
        {

            return await _competitionsBusiness.getCurrentCapacity(competitionId);

        }



        [HttpGet]
        [Route("deleteCompetition")]
        public async Task<bool> deleteCompetition(int competitionId)
        { 
        
           return await _competitionsBusiness.deleteCompetition(competitionId);
        
        }


    }
}
