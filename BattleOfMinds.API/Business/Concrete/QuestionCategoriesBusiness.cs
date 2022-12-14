using BattleOfMinds.API.Business.Abstract;
using BattleOfMinds.API.Context;
using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business
{
    public class QuestionCategoriesBusiness : IQuestionCategoriesBusiness
    {
        private readonly IEntityRepository<QuestionCategories> _entityRepository;

        public QuestionCategoriesBusiness(IEntityRepository<QuestionCategories> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Task<QuestionCategories> Add(QuestionCategories Entity)
        {
            var result = _entityRepository.GetAll(o => o.QuestionCategoryName.Equals(Entity.QuestionCategoryName) && o.isDeleted == false).Result.FirstOrDefault();
            if (result == null)
                return _entityRepository.Add(Entity);
            else return null;
        }

        public Task<QuestionCategories> Get(Expression<Func<QuestionCategories, bool>> filter = null, params Expression<Func<QuestionCategories, object>>[] includes)
        {
            return _entityRepository.Get(filter,includes);
        }

        public Task<List<QuestionCategories>> GetAll(Expression<Func<QuestionCategories, bool>> filter = null, params Expression<Func<QuestionCategories, object>>[] includes)
        {
            return _entityRepository.GetAll(filter,includes);
        }

        public Task<QuestionCategories> Update(QuestionCategories Entity)
        {
            return _entityRepository.Update(Entity);
        }

        public Task<QuestionCategories> Remove(QuestionCategories Entity)
        {

            return _entityRepository.Remove(Entity);
        
        }


    }
}
