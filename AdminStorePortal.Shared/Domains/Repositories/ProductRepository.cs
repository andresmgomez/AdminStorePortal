using AdminStorePortal.Data;
using AdminStorePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private ApplicationDbContext _dataContext;

    public ProductRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
    public void SaveProduct()
    {
        _dataContext.SaveChanges();
    }

    public void UpdateProduct(Product singleProduct)
    {
        _dataContext.StoreProducts.Update(singleProduct);
    }
}

