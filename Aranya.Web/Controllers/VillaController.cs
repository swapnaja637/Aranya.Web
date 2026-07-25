using Aranya.Application.Generic.Interfaces;
using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aranya.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaController(IUnitOfWork villaRepo)
        {
            _unitOfWork = villaRepo;
        }
        public async Task<IActionResult> Index()
        {
            var villas = await _unitOfWork.villa.GetAllAsync();
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Villa villa)
        {
            if (villa.Name != null && villa.Description != null)
            {
                if (villa.Name.ToLower() == villa.Description.ToLower())
                {
                    ModelState.AddModelError("", "The villa name and descripton should be different.");
                }
            }
            if (ModelState.IsValid)
            {
                villa.CreatedDate = DateTime.Now;
                bool Flag = _unitOfWork.villa.Add(villa);
                _unitOfWork.villa.Save();
                TempData["success"] = " Record added successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = " Record not added successfully.";
                return View();
            }
        }
        public async Task<IActionResult> Update(int villaId)
        {
            Villa? villa = await _unitOfWork.villa.GetAsync(u => u.Id == villaId);
            if (villa == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(villa);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(Villa villa)
        {
            if (ModelState.IsValid && villa.Id != null)
            {
                _unitOfWork.villa.Update(villa);
                _unitOfWork.villa.Save();
                TempData["success"] = "Record updated succcessfully.";
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Record not updated.");
                TempData["error"] = "Record not updated succcessfully.";
                return View();
            }

        }
        public async Task<IActionResult> Delete(int Id)
        {
            Villa? villa = await _unitOfWork.villa.GetAsync(u => u.Id == Id);
            if (villa != null)
            {

                if (villa.Id != 0)
                {
                    _unitOfWork.villa.Delete(villa);
                    _unitOfWork.villa.Save();
                    TempData["success"] = "Record deleted succcessfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    // ModelState.AddModelError("", "Record not removed");
                    TempData["error"] = "Record not deleted succcessfully.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }

}
