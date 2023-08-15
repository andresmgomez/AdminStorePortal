using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public interface IBaseRepository<T> where T : class
{
    T GetSingleEntity(Expression<Func<T, bool>> filter);
    IEnumerable<T> GetAllEntities();

    void AddEntity(T entity);
    void RemoveEntity(T entity);
}
