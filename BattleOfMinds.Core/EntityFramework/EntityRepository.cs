using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace BattleOfMinds.Core.EntityFramework
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var added = context.AddAsync(entity);
                context.SaveChanges();
                return added.Result.Entity;
            }
            
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updated = context.Update(entity);
                context.SaveChanges();
                return updated.Entity;
            }
        }
    }
}
