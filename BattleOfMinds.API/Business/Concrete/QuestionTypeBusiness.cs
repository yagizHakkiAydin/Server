using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business
{
    public class QuestionTypeBusiness : IQuestionTypeBusiness
    {

        private readonly IEntityRepository<QuestionType> _entityRepository;

        public QuestionTypeBusiness(IEntityRepository<QuestionType> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Task<QuestionType> Add(QuestionType Entity)
        {
            var result = _entityRepository.GetAll(o => o.QuestionTypeName.Equals(Entity.QuestionTypeName) && o.isDeleted == false).Result.FirstOrDefault();
            if (result == null)
                return _entityRepository.Add(Entity);
            else return null;
        }

        public Task<QuestionType> Get(Expression<Func<QuestionType, bool>> filter = null, params Expression<Func<QuestionType, object>>[] includes)
        {
            return _entityRepository.Get(filter,includes);
        }

        public Task<List<QuestionType>> GetAll(Expression<Func<QuestionType, bool>> filter = null, params Expression<Func<QuestionType, object>>[] includes)
        {
            return _entityRepository.GetAll(filter,includes);
        }

        public Task<QuestionType> Update(QuestionType Entity)
        {
            return _entityRepository.Update(Entity);
        }

        public Task<QuestionType> Remove(QuestionType Entity)
        {

            return _entityRepository.Remove(Entity);

        }

    }
}
