using Microsoft.EntityFrameworkCore;
using StoreSolution.Web.Models;

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
    }
}
