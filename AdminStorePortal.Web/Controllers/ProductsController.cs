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
        IEnumerable<LineProduct>currentProducts = _unitOfWork.StoreProduct.GetAllEntities();
        return View(currentProducts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(LineProduct lineProduct)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.StoreProduct.AddAction(lineProduct);
            _unitOfWork.SaveAction();
            TempData["success"] = "Store Product Added Successfully";
            return RedirectToAction("Index");
        }

        return View(lineProduct);
    }

    [HttpGet]
    public IActionResult Edit(int? Id)
    {
        // Find the productId that matches a store product
        var selectedProduct = _unitOfWork.StoreProduct.GetSingleEntity(storeProduct => storeProduct.Id == Id);

        // Display product info if a valid productId is found
        return selectedProduct == null || selectedProduct.Id != Id ? NotFound() : View(selectedProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(LineProduct lineProduct) 
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.StoreProduct.UpdateProduct(lineProduct);
            _unitOfWork.SaveAction();
            TempData["success"] = "Store Product Changed Successfully";
            return RedirectToAction("Index");
        }

        return View(lineProduct);
    }


    [HttpGet]
    public IActionResult Delete(int? Id)
    {
        var selectedProduct = _unitOfWork.StoreProduct.GetSingleEntity(storeProduct => storeProduct.Id == Id);

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
        var selectedProduct = _unitOfWork.StoreProduct.GetSingleEntity(storeProduct => storeProduct.Id == Id);

        if (selectedProduct == null)
        {
            return NotFound();
        }

        _unitOfWork.StoreProduct.RemoveAction(selectedProduct);
        _unitOfWork.SaveAction();
        return RedirectToAction("Index");
    }
}
