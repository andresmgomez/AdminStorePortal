using Microsoft.AspNetCore.Mvc;
using StoreSolution.Web.Data;
using StoreSolution.Web.Models;
using System.Collections.Generic;

namespace StoreSolution.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _dataContext;

        public ProductsController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;   
        }

        public IActionResult Index()
        {
            IEnumerable<Product>currentProducts = _dataContext.StoreProducts.ToList();
            return View(currentProducts);
        }
    }
}
