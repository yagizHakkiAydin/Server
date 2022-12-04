using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface IQuestionCategoriesBusiness : IEntityRepository<QuestionCategories>
    {

        public Task<QuestionCategories> Add(QuestionCategories Entity);
        public Task<QuestionCategories> Get(Expression<Func<QuestionCategories, bool>> filter = null);
        public Task<List<QuestionCategories>> GetAll(Expression<Func<QuestionCategories, bool>> filter = null);
        public Task<QuestionCategories> Update(QuestionCategories Entity);
    }
}
