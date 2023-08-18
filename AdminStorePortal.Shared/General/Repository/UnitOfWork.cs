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
        RetailProduct = new RetailProductRepo(_dbContext);
    }

    public IRetailProductRepo RetailProduct { get; private set; }

    public void SaveAction()
    {
        _dbContext.SaveChanges();
    }
}
