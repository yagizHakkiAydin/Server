using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Core.DataAccess;
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

        public Task<Questions> Get(Expression<Func<Questions, bool>> filter = null)
        {
            return _entityRepository.Get(filter);
        }

        public Task<List<Questions>> GetAll(Expression<Func<Questions, bool>> filter = null)
        {
            return _entityRepository.GetAll(filter);
        }

        public Task<Questions> Update(Questions Entity)
        {
            return _entityRepository.Update(Entity);
        }


    }
}
