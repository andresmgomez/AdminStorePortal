using AdminStorePortal.Data;
using AdminStorePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public class StoreProductRepo : BaseRepository<LineProduct>, IStoreProductRepo
{
    private ApplicationDbContext _dataContext;

    public StoreProductRepo(ApplicationDbContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
}
