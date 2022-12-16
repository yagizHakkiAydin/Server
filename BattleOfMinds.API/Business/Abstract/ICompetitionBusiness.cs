using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface ICompetitionBusiness : IEntityRepository<Competitions>
    {
        public Task<Competitions> Add(Competitions Entity);
        public Task<Competitions> Get(Expression<Func<Competitions, bool>> filter = null, params Expression<Func<Competitions, object>>[] includes);
        public Task<List<Competitions>> GetAll(Expression<Func<Competitions, bool>> filter = null, params Expression<Func<Competitions, object>>[] includes);
        public Task<Competitions> Update(Competitions Entity);
        public Task<Users> findCompetition(int userId, string GameMode);
        public Task<bool> isStarted(int competitionId);
        public Task<Questions> getQuestion(int competitionId);
        public Task<Questions> chooseQuestion(int competitionId);
        public Task<int> decreaseCapacity(int competitionId);
        public Task<bool> wrongAnswer([FromBody] Users user);
        public Task<bool> trueAnswer([FromBody] Users user);
        public Task<int> getCurrentCapacity(int competitionId);
        public Task<bool> deleteCompetition(int competitionId);
        public Task<bool> exitCompetition(int userId);

    }
}
