using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminStorePortal.Data;

namespace AdminStorePortal.Shared;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        StoreProduct = new ProductRepository(_dbContext);
    }

    public IProductRepository StoreProduct { get; private set; }

    public void SaveAction()
    {
        _dbContext.SaveChanges();
    }
}
