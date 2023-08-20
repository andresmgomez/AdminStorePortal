using AdminStorePortal.Entities;
using AdminStorePortal.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdminStorePortal.Web;

[Area("Products")]
public class DealController : NotificationsController
{
    private readonly IUnitOfWork _unitOfWork;

    public DealController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Upsert(int? Id)
    {
        // Find the productId that matches a store product
        var selectedProduct = _unitOfWork.PromoProduct.GetSingleEntity(discountProduct => discountProduct.Id == Id);

        // Display product info if a valid productId is found
        return Id == null || Id == 0 ? View() : View(selectedProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(DealProduct dealProduct)
    {
        if (ModelState.IsValid)
        {
            if (dealProduct != null)
            {
                _unitOfWork.PromoProduct.UpdateAction(dealProduct);
                _unitOfWork.SaveAction();
                TempData["success"] = "Fabric Product Changed Successfully";
                // return RedirectToAction("Index");
            }
            else
            {
                _unitOfWork.PromoProduct.AddAction(dealProduct);
                _unitOfWork.SaveAction();
                TempData["success"] = "Fabric Product Added Successfully";
                // return RedirectToAction("Index");
            }
        }

        return View(dealProduct);
    }

}
