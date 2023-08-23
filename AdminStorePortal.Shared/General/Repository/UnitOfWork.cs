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

        // Instances of Products's categories
        CategoryMaterial = new CategoryMaterialRepo(dbContext);
        CategoryStyle = new CategoryStyleRepo(dbContext);

        // Instances of Store's products
        RawProduct = new RawProductRepo(_dbContext);
        StoreProduct = new StoreProductRepo(_dbContext);
        PromoProduct = new PromoProductRepo(_dbContext);
    }

    // Private implementation of Product's categories
    public ICategoryMaterialRepo CategoryMaterial { get; private set; }
    public ICategoryStyleRepo CategoryStyle { get; private set; }

    // Private implementation of Store's products
    public IRawProductRepo RawProduct { get; private set; }
    public IStoreProductRepo StoreProduct { get; private set; }
    public IPromoProductRepo PromoProduct { get; private set; }

    public RetailProductVM GetRetailProducts()
    {
        RetailProductVM retailProducts = new RetailProductVM()
        {
            LineProducts = _dbContext.LineProduct.ToList(),
            FabricProducts = _dbContext.FabricProduct.ToList(),
        };

        return retailProducts;
    }

    public OnlineProductVM GetOnlineProducts()
    {
        OnlineProductVM onlineProducts = new OnlineProductVM()
        {
            LineProducts = _dbContext.LineProduct.ToList(),
            DealProducts = _dbContext.DealProduct.ToList()
        };

        return onlineProducts;
    }


    public void SaveAction()
    {
        _dbContext.SaveChanges();
    }
}
