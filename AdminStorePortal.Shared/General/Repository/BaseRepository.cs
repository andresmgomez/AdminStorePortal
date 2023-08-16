
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AdminStorePortal.Data;

namespace AdminStorePortal.Shared;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _dataContext;
    internal DbSet<T> dataSet;

    public BaseRepository(ApplicationDbContext dataContext)
    {
        _dataContext = dataContext;
        dataSet = _dataContext.Set<T>();
    }

    public void AddAction(T entity)
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

    public void RemoveAction(T entity)
    {
        dataSet.Remove(entity);
    }
}
