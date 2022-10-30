using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IEntityRepository<Users> _entityRepository;

        public UsersBusiness(IEntityRepository<Users> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Task<Users> Add(Users Entity)
        {
            var result = _entityRepository.GetAll(o => o.Email.Equals(Entity.Email) && o.isDeleted == false).Result.FirstOrDefault();
            if (result == null)
                return _entityRepository.Add(Entity);
            else return null;
        }

        public Task<Users> Get(Expression<Func<Users, bool>> filter = null)
        {
            return _entityRepository.Get(filter);
        }

        public Task<List<Users>> GetAll(Expression<Func<Users, bool>> filter = null)
        {
            return _entityRepository.GetAll(filter);
        }

        public Task<Users> Update(Users Entity)
        {
            return _entityRepository.Update(Entity);
        }


    }
}
