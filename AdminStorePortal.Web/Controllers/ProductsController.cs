using Microsoft.AspNetCore.Mvc;
using AdminStorePortal.Data;
using AdminStorePortal.Entities;

namespace AdminStorePortal.Web;

public class ProductsController : NotificationsController
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
            TempData["success"] = "Store Product Added Successfully";
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
            TempData["success"] = "Store Product Changed Successfully";
            return RedirectToAction("Index");
        }

        return View(storeProduct);
    }


    [HttpGet]
    public IActionResult Delete(int? Id)
    {
        var selectedProduct = _dataContext.StoreProducts.FirstOrDefault(
                storeProduct => storeProduct.Id == Id);

        if (selectedProduct == null || selectedProduct.Id != Id)
        {
            return NotFound();
        }

        CustomNotification("Are you sure you want to remove this item?", NotificationType.Error, "center", selectedProduct.Name);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int Id)
    {
        var selectedProduct = _dataContext.StoreProducts.Find(Id);

        if (selectedProduct == null)
        {
            return NotFound();
        }

        _dataContext.StoreProducts.Remove(selectedProduct);
        _dataContext.SaveChanges();
        return RedirectToAction("Index");
    }
}
