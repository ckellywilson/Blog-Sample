using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Repository.Interfaces
{
    /// <summary>
    ///     Interface to select
    ///     <typeparam name="TEntity">TEntity</typeparam>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISelectRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<TEntity>> Get(int id, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}