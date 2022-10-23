using BattleOfMinds.Models.Models;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface IQuestionTypeBusiness
    {

        public IEnumerable<QuestionType> Get(int id);

        public IEnumerable<QuestionType> GetAll();

    }
}
