﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Shared;

public interface IUnitOfWork
{
    IProductRepository StoreProduct { get; }

    void SaveAction();

}
