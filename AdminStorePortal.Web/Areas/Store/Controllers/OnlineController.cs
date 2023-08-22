using AdminStorePortal.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdminStorePortal.Web;

[Area("Store")]
public class OnlineController : NotificationsController
{
    private readonly IUnitOfWork _unitOfWork;

    public OnlineController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var onlineProducts = _unitOfWork.GetOnlineProducts();

        return View(onlineProducts);
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
}
