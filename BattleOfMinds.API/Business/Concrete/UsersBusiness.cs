using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Models.Models;

namespace BattleOfMinds.API.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private BattleOfMindsDbContext _dbContext = new BattleOfMindsDbContext();
        public IEnumerable<Users> Get(int id)
        {
            return _dbContext.Users.Where(o => o.Id.Equals(id));
        }
        public IEnumerable<Users> GetAll()
        {
            return _dbContext.Users.ToList();
        }

    }
}
