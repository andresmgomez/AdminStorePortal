namespace AdminStorePortal.Entities;

public class RetailProductVM
{
    public IEnumerable<FabricProduct> FabricProducts { get; set; }
    public IEnumerable<LineProduct> LineProducts { get; set; }
}
