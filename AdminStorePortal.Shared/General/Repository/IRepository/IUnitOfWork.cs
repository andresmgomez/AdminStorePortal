using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public interface IUnitOfWork
{
    IRawProductRepo RawProduct { get; }
    IStoreProductRepo StoreProduct { get; }

    void SaveAction();

}
