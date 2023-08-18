using Microsoft.EntityFrameworkCore;
using AdminStorePortal.Entities;

namespace AdminStorePortal.Data;

public class ApplicationDbContext: DbContext 
{
    /// <summary>
    /// Make an instance of database context and pass it to the application
    /// </summary>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    // Code first approach for creating an SQL table
    public DbSet<LineProduct> StoreProducts { get; set; }
}
