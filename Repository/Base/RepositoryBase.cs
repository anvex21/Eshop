using System.Linq.Expressions;
using Contracts.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Repository.Base;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    /// <inheritdoc/>
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).ToList();
    }

    /// <inheritdoc/>
    public T GetById(long id)
    {
        return _context.Set<T>().Find(id);
    }

    /// <inheritdoc/>
    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}
