using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Models.Models;


namespace BattleOfMinds.API.Business
{
    public class QuestionsBusiness : IQuestionsBusiness
    {


        private BattleOfMindsDbContext _dbContext = new BattleOfMindsDbContext();
        public IEnumerable<Questions> Get(int id)
        {
            return _dbContext.Questions.Where(o => o.Id.Equals(id));
        }
        public IEnumerable<Questions> GetAll()
        {
            return _dbContext.Questions.ToList();
        }

    }
}
