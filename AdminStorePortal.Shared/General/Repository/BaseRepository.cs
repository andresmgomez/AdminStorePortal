
using System.Linq.Expressions;
using AdminStorePortal.Data;
using Microsoft.EntityFrameworkCore;

namespace AdminStorePortal.Shared;

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dataContext;
    internal DbSet<T> dataSet;

    public BaseRepository(ApplicationDbContext dataContext)
    {
        _dataContext = dataContext;
        dataSet = _dataContext.Set<T>();
    }

    public void AddEntity(T entity)
    {
        dataSet.Add(entity);
    }

    public IEnumerable<T> GetAllEntities()
    {
        IQueryable<T> dataQuery = dataSet;
        return dataQuery.ToList();
    }

    public T GetSingleEntity(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> dataQuery = dataSet;
        dataQuery = dataQuery.Where(filter);
        return dataQuery.FirstOrDefault();
    }

    public void RemoveEntity(T entity)
    {
        dataSet.Remove(entity);
    }
}
