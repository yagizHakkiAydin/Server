using BattleOfMinds.Core.DataAccess;
using BattleOfMinds.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
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


        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {

                IQueryable<TEntity> queryable = context.Set<TEntity>();

                if (filter != null)
                {
                    queryable = queryable.Where(filter);
                }

                if (includes is { Length: > 0 })
                {
                    queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
                }

                return queryable.AsNoTracking().SingleOrDefault();
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> queryable = context.Set<TEntity>();
                if (filter != null)
                {
                    queryable = queryable.Where(filter);
                }

                if (includes is { Length: > 0 })
                {
                    queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
                }

                return await queryable.AsNoTracking().ToListAsync();
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

        public async Task<TEntity> Remove(TEntity Entity)
        {
            using (var context = new TContext())
            {
                var deleted = context.Remove(Entity);
                context.SaveChanges();
                return deleted.Entity;

            }

        }

    }
}
