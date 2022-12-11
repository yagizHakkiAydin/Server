using BattleOfMinds.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfMinds.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        public Task<T> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        public Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        public Task<T> Add(T Entity);
        public Task<T> Update(T Entity);
    }
}
