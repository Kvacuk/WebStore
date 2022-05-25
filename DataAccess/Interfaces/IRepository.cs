using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity,TKey> where TEntity : class
    {
        /// <summary>Gets all asynchronous.</summary>
        public Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>Gets the entity by identifier asynchronous.</summary>
        /// <param name="id">The identifier.</param>
        public Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>Gets the Entity by name asynchronous.</summary>
        /// <param name="name">The name.</param>
        public Task<TEntity> GetByNameAsync(string name);

        /// <summary>Gets the range of entities by name asynchronous.</summary>
        /// <param name="name">The name.</param>
        public Task<IEnumerable<TEntity>> GetRangeByNameAsync(string name);

        /// <summary>Counts entities by specified expression.</summary>
        /// <param name="expression">The expression.</param>
        public Task<int> CountAsync(Func<TEntity, bool> expression);

        /// <summary>Anies entities specified expression.</summary>
        /// <param name="expression">The expression.</param>
        public Task<bool> AnyAsync(Func<TEntity, bool> expression);

        /// <summary>Adds entity asynchronous.</summary>
        /// <param name="entity">The entity.</param>
        public Task AddAsync(TEntity entity);


        /// <summary>Adds the range of entities asynchronous.</summary>
        /// <param name="entities">The entities.</param>
        public Task AddRangeAsync(IEnumerable<TEntity> entities);


        /// <summary>Updates the entity asynchronous.</summary>
        /// <param name="entity">The entity.</param>
        public Task UpdateAsync(TEntity entity);


        /// <summary>Updates the range of entities asynchronous</summary>
        /// <param name="entities">The entities.</param>
        public Task UpdateRangeAsync(IEnumerable<TEntity> entities);


        /// <summary>Removes the entity asynchronous.</summary>
        /// <param name="entity">The entity.</param>
        public Task RemoveAsync(TEntity entity);


        /// <summary>Removes the range of entities asynchronous.</summary>
        /// <param name="entities">The entities.</param>
        public Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
