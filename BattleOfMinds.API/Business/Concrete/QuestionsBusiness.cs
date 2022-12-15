using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Core.Entity;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;


namespace BattleOfMinds.API.Business
{
    public class QuestionsBusiness : IQuestionsBusiness
    {

        private readonly IEntityRepository<Questions> _entityRepository;

        public QuestionsBusiness(IEntityRepository<Questions> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Task<Questions> Add(Questions Entity)
        {
         
            return _entityRepository.Add(Entity);
        }

        public Task<Questions> Get(Expression<Func<Questions, bool>> filter = null, params Expression<Func<Questions, object>>[] includes)
        {
            return _entityRepository.Get(filter,includes);
        }

        public async Task<List<Questions>> GetAll(Expression<Func<Questions, bool>> filter = null, params Expression<Func<Questions, object>>[] includes)
        {
            List<Questions> questions = new List<Questions>();

            return await _entityRepository.GetAll(filter,includes);

        }

        public Task<Questions> Update(Questions Entity)
        {
            return _entityRepository.Update(Entity);
        }

        public Task<Questions> Remove(Questions Entity)
        {

            return _entityRepository.Remove(Entity);

        }


    }
}
