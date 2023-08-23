using AdminStorePortal.Data;
using AdminStorePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public class CategoryMaterialRepo : BaseRepository<ClothingMaterial>, ICategoryMaterialRepo
{
    private ApplicationDbContext _dataContext;

    public CategoryMaterialRepo(ApplicationDbContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
}
