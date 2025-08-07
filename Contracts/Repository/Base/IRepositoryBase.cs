using System.Linq.Expressions;

namespace Contracts.Repository.Base;

/// <summary>
/// Repository Base
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Get all entities
    /// </summary>
    IEnumerable<T> GetAll();

    /// <summary>
    /// Get all entities matching the condition
    /// </summary>
    /// <param name="expression">Filter expression</param>
    IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Get entity by ID
    /// </summary>
    T GetById(long id);

    /// <summary>
    /// Create new entity
    /// </summary>
    void Create(T entity);

    /// <summary>
    /// Update entity
    /// </summary>
    void Update(T entity);

    /// <summary>
    /// Delete entity
    /// </summary>
    void Delete(T entity);
}
