using AdminStorePortal.Entities;
using AdminStorePortal.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdminStorePortal.Web;

[Area("Products")]
public class OnlineController : NotificationsController
{
    private readonly IUnitOfWork _unitOfWork;

    public OnlineController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<LineProduct> lineProducts = _unitOfWork.StoreProduct.GetAllEntities();

        return View(lineProducts);
    }


    [HttpGet]
    public IActionResult Delete(int? Id)
    {
        var selectedProduct = _unitOfWork.StoreProduct.GetSingleEntity(lineProduct => lineProduct.Id == Id);

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
