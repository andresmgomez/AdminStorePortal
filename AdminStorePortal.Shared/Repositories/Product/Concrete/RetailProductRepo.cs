using AdminStorePortal.Data;
using AdminStorePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public class RetailProductRepo : BaseRepository<RetailProduct>, IRetailProductRepo
{
    private ApplicationDbContext _dataContext;

    public RetailProductRepo(ApplicationDbContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public void UpdateProduct(RetailProduct singleProduct)
    {
        _dataContext.RetailProduct.Update(singleProduct);
    }


}
