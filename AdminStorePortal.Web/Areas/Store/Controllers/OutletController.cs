﻿using AdminStorePortal.Entities;
using AdminStorePortal.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdminStorePortal.Web;

[Area("Store")]
public class OutletController : NotificationsController
{
    private readonly IUnitOfWork _unitOfWork;

    public OutletController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var retailProducts = _unitOfWork.GetRetailProducts();

        return View(retailProducts);
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
    // public IActionResult DeleteProduct(int Id)
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
