using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminStorePortal.Data;
using AdminStorePortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminStorePortal.Shared;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        //
        RawProduct = new RawProductRepo(_dbContext);
        StoreProduct = new StoreProductRepo(_dbContext);
    }

    public IRawProductRepo RawProduct { get; private set; }
    public IStoreProductRepo StoreProduct { get; private set; }

    public RetailProductVM GetRetailProducts()
    {
        RetailProductVM onlineProduct = new RetailProductVM()
        {
            FabricProducts = _dbContext.FabricProduct.ToList(),
            LineProducts = _dbContext.LineProduct.ToList()
        };

        return onlineProduct;
    }


    public void SaveAction()
    {
        _dbContext.SaveChanges();
    }
}
