using BattleOfMinds.Models.Models;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface IUsersBusiness
    {

        public IEnumerable<Users> Get(int id);

        public IEnumerable<Users> GetAll();


    }
}
