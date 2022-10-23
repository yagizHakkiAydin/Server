using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Models.Models;

namespace BattleOfMinds.API.Business
{
    public class QuestionTypeBusiness : IQuestionTypeBusiness
    {

        private BattleOfMindsDbContext _dbContext = new BattleOfMindsDbContext();
        public IEnumerable<QuestionType> Get(int id)
        {
            return _dbContext.QuestionType.Where(o => o.Id.Equals(id));
        }
        public IEnumerable<QuestionType> GetAll()
        {
            return _dbContext.QuestionType.ToList();
        }

    }
}
