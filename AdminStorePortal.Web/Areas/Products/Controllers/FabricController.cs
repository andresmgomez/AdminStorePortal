using AdminStorePortal.Entities;
using AdminStorePortal.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdminStorePortal.Web;

[Area("Products")]
public class FabricController : NotificationsController
{
    private readonly IUnitOfWork _unitOfWork;

    public FabricController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Upsert(int? Id)
    {
        // Find the productId that matches a store product
        var selectedProduct = _unitOfWork.RawProduct.GetSingleEntity(fabricProduct => fabricProduct.Id == Id);

        // Display product info if a valid productId is found
        return Id == null || Id == 0 ? View() : View(selectedProduct);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(FabricProduct fabricProduct)
    {
        if (ModelState.IsValid)
        {
            if (fabricProduct != null)
            {
                _unitOfWork.RawProduct.UpdateAction(fabricProduct);
                _unitOfWork.SaveAction();
                TempData["success"] = "Fabric Product Changed Successfully";
                // return RedirectToAction("Index");
            }
            else
            {
                _unitOfWork.RawProduct.AddAction(fabricProduct);
                _unitOfWork.SaveAction();
                TempData["success"] = "Fabric Product Added Successfully";
                // return RedirectToAction("Index");
            }
        }

        return View(fabricProduct);
    }

}
