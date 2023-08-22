using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Entities;

public class OnlineProductVM
{
    public IEnumerable<LineProduct> LineProducts { get; set; }
    public IEnumerable<DealProduct> DealProducts { get; set; }
}
