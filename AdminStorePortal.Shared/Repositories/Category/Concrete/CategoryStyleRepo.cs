using AdminStorePortal.Data;
using AdminStorePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public class CategoryStyleRepo : BaseRepository<ClothingStyle>, ICategoryStyleRepo
{
    private ApplicationDbContext _dataContext;

    public CategoryStyleRepo(ApplicationDbContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
}
