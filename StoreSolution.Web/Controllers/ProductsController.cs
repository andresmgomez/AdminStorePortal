using Microsoft.AspNetCore.Mvc;
using StoreSolution.Web.Data;
using StoreSolution.Web.Models;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product storeProduct)
        {
            if (ModelState.IsValid)
            {
                _dataContext.StoreProducts.Add(storeProduct);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeProduct);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            // Find the productId that matches a store product
            var selectedProduct = _dataContext.StoreProducts.SingleOrDefault(
                storeProduct => storeProduct.Id == Id);

            // Display product info if a valid productId is found
            return selectedProduct == null || selectedProduct.Id != Id ? NotFound() : View(selectedProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product storeProduct) 
        {
            if (ModelState.IsValid)
            {
                _dataContext.StoreProducts.Update(storeProduct);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeProduct);
        }
    }
}
