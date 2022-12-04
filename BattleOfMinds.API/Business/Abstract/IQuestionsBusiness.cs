using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Models.Models;
using System.Linq.Expressions;

namespace BattleOfMinds.API.Business.Abstract
{
    public interface IQuestionsBusiness : IEntityRepository<Questions>
    {
        public Task<Questions> Add(Questions Entity);
        public Task<Questions> Get(Expression<Func<Questions, bool>> filter = null);
        public Task<List<Questions>> GetAll(Expression<Func<Questions, bool>> filter = null);
        public Task<Questions> Update(Questions Entity);
    }
}
