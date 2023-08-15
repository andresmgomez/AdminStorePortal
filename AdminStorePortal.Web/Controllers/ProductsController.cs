using Microsoft.AspNetCore.Mvc;
using AdminStorePortal.Entities;
using AdminStorePortal.Shared;

namespace AdminStorePortal.Web;

public class ProductsController : NotificationsController
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product>currentProducts = _unitOfWork.Product.GetAllEntities();
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
            _unitOfWork.Product.AddEntity(storeProduct);
            _unitOfWork.SaveEntity();
            TempData["success"] = "Store Product Added Successfully";
            return RedirectToAction("Index");
        }

        return View(storeProduct);
    }

    [HttpGet]
    public IActionResult Edit(int? Id)
    {
        // Find the productId that matches a store product
        var selectedProduct = _unitOfWork.Product.GetSingleEntity(storeProduct => storeProduct.Id == Id);

        // Display product info if a valid productId is found
        return selectedProduct == null || selectedProduct.Id != Id ? NotFound() : View(selectedProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product storeProduct) 
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Product.UpdateProduct(storeProduct);
            _unitOfWork.SaveEntity();
            TempData["success"] = "Store Product Changed Successfully";
            return RedirectToAction("Index");
        }

        return View(storeProduct);
    }


    [HttpGet]
    public IActionResult Delete(int? Id)
    {
        var selectedProduct = _unitOfWork.Product.GetSingleEntity(storeProduct => storeProduct.Id == Id);

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
        var selectedProduct = _unitOfWork.Product.GetSingleEntity(storeProduct => storeProduct.Id == Id);

        if (selectedProduct == null)
        {
            return NotFound();
        }

        _unitOfWork.Product.RemoveEntity(selectedProduct);
        _unitOfWork.SaveEntity();
        return RedirectToAction("Index");
    }
}
