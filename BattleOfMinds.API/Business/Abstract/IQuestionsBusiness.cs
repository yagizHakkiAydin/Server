using BattleOfMinds.Models.Models;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface IQuestionsBusiness
    {
        public IEnumerable<Questions> Get(int id);

        public IEnumerable<Questions> GetAll();

    }
}
