using AdminStorePortal.Entities;
using AdminStorePortal.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdminStorePortal.Web;

[Area("Products")]
public class RetailController : NotificationsController
{
    private readonly IUnitOfWork _unitOfWork;

    public RetailController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RetailProduct lineProduct)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.RetailProduct.AddAction(lineProduct);
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
        var selectedProduct = _unitOfWork.RetailProduct.GetSingleEntity(storeProduct => storeProduct.Id == Id);

        // Display product info if a valid productId is found
        return selectedProduct == null || selectedProduct.Id != Id ? NotFound() : View(selectedProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(RetailProduct lineProduct)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.RetailProduct.UpdateProduct(lineProduct);
            _unitOfWork.SaveAction();
            TempData["success"] = "Store Product Changed Successfully";
            return RedirectToAction("Index");
        }

        return View(lineProduct);
    }

    [HttpGet]
    public IActionResult Delete(int? Id)
    {
        var selectedProduct = _unitOfWork.RetailProduct.GetSingleEntity(storeProduct => storeProduct.Id == Id);

        if (selectedProduct == null || selectedProduct.Id != Id)
        {
            return NotFound();
        }

        CustomNotification("Are you sure you want to remove this item?", NotificationType.Error, "center", selectedProduct.Name);
        return RedirectToAction(nameof(Index));
    }

    // [HttpPost]
    // public IActionResult Delete(int Id)
    // {
    //    var selectedProduct = _unitOfWork.StoreProduct.GetSingleEntity(storeProduct => storeProduct.Id == Id);
    //
    //    if (selectedProduct == null)
    //    {
    //        return NotFound();
    //    }
    //
    //    _unitOfWork.StoreProduct.RemoveAction(selectedProduct);
    //    _unitOfWork.SaveAction();
    //    return RedirectToAction("Index");
    // }
}
