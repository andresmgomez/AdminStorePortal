using AdminStorePortal.Entities;
using AdminStorePortal.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    public IActionResult Upsert(int? Id)
    {// Find the productId that matches a store product
        var selectedProduct = _unitOfWork.StoreProduct.GetSingleEntity(lineProduct => lineProduct.Id == Id);

        // Display product info if a valid productId is found
        return Id == null || Id == 0 ? View() : View(selectedProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(LineProduct lineProduct)
    {
        if (ModelState.IsValid)
        {
            if (lineProduct != null)
            {
                _unitOfWork.StoreProduct.UpdateAction(lineProduct);
                _unitOfWork.SaveAction();
                TempData["success"] = "Line Product Changed Successfully";
            } else 
            {
                _unitOfWork.StoreProduct.AddAction(lineProduct);
                _unitOfWork.SaveAction();
                TempData["success"] = "Line Product Added Successfully";
            }
        }

        return View(lineProduct);
    }
}
