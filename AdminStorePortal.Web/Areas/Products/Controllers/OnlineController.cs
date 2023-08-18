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
        IEnumerable<RetailProduct> retailProducts = _unitOfWork.RetailProduct.GetAllEntities();

        return View(retailProducts);
    }
}
