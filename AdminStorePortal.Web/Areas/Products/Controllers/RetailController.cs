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
    {
        LineProduct selectedProduct = new();
        IEnumerable<SelectListItem> productMaterials = _unitOfWork.CategoryMaterial.GetAllEntities().Select(
            category => new SelectListItem
            {
                Text = category.Material,
                Value = category.Id.ToString()
            });

        IEnumerable<SelectListItem> productStyles = _unitOfWork.CategoryStyle.GetAllEntities().Select(
            category => new SelectListItem
            {
                Text = category.Style,
                Value = category.Id.ToString()
            });

        ViewBag.ProductMaterials = productMaterials;
        ViewBag.ProductStyles = productStyles;

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
                // return RedirectToAction("Index");
            } else 
            {
                _unitOfWork.StoreProduct.AddAction(lineProduct);
                _unitOfWork.SaveAction();
                TempData["success"] = "Line Product Added Successfully";
                // return RedirectToAction("Index");
            }
        }

        return View(lineProduct);
    }
}
