using Microsoft.EntityFrameworkCore;
using StoreSolution.Web.Models;
using StoreSolution.Web.Models.Products;

namespace StoreSolution.Web.Data
{
    public class ApplicationDbContext: DbContext 
    {
        /// <summary>
        /// Make an instance of database context and pass it to the application
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // Code first approach for creating an SQL table
        public DbSet<Department> Departments { get; set; }
        
        //
        public DbSet<ProductFactory> StoreProducts { get; set; }
        public DbSet<ProductMeasurement> FabricProducts { get; set; }
        public DbSet<ProductLine> RetailProducts { get; set; }
        public DbSet<ProductVariation> OnlineProducts { get; set; }
        public DbSet<ProductPromo> DealProducts { get; set; }

    }
}
