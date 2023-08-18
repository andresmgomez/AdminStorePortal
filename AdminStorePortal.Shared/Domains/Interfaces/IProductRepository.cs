using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminStorePortal.Entities;

namespace AdminStorePortal.Shared;

public interface IProductRepository : IBaseRepository<LineProduct>
{
    void UpdateProduct(LineProduct lineProduct);

}