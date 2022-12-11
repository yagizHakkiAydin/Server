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


    }
}
