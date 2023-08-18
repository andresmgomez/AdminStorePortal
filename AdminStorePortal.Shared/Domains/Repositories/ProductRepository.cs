using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AdminStorePortal.Data;
using AdminStorePortal.Entities;

namespace AdminStorePortal.Shared;

public class ProductRepository : BaseRepository<LineProduct>, IProductRepository
{
    private ApplicationDbContext _dataContext;

    public ProductRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
 
    public void UpdateProduct(LineProduct singleProduct)
    {
        _dataContext.StoreProducts.Update(singleProduct);
    }
}

