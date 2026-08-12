using Aranya.Application.Generic.Interfaces;
using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Aranya.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _WebhostEnvironment;
        public VillaController(IUnitOfWork villaRepo, IWebHostEnvironment webhosting)
        {
            _unitOfWork = villaRepo;
            _WebhostEnvironment = webhosting;
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
                if (villa.ImageUrl != "")
                {
                    string FileExtension = Path.GetExtension(villa.Image.FileName);
                    string FileName = Guid.NewGuid().ToString() + FileExtension;
                    string FilePath = Path.Combine(_WebhostEnvironment.WebRootPath, @"images\Villa");
                    if (!(FileExtension.ToString().Trim().ToLower().Contains(".png") ||
                        FileExtension.ToString().Trim().ToLower().Contains(".jpg")))
                    {
                        ModelState.AddModelError("", "Only png and jpg formats allowed.");
                    }
                    else
                    {
                        using var fileStream = new FileStream(Path.Combine(FilePath, FileName), FileMode.Create);
                            villa.Image.CopyTo(fileStream);
                        villa.ImageUrl = @"images/Villa/" + FileName;
                    }
                }
                villa.CreatedDate = DateTime.Now;
                bool Flag = _unitOfWork.villa.Add(villa);
                _unitOfWork.Save();
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
            try
            { 
                Villa? villa = await _unitOfWork.villa.GetAsync(u => u.Id == villaId);
                if (villa == null)
                {
                    return RedirectToAction("Error","Home");
                }
                else
                {
                    return View(villa);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(Villa villa)
        {
            if (ModelState.IsValid && villa.Id != null)
            {
                if (villa == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                else
                {
                    if (villa.Image != null)
                    {
                        var FileName = Guid.NewGuid().ToString() + Path.GetExtension(villa.Image.FileName);
                        var ImagePath = Path.Combine(_WebhostEnvironment.WebRootPath, @"Images\Villa");
                        if (villa.ImageUrl != null && villa.ImageUrl.Trim() != "")
                        {
                            var OldImagePath = Path.Combine(_WebhostEnvironment.WebRootPath, villa.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(OldImagePath))
                            {
                                System.IO.File.Delete(OldImagePath);
                            }
                        }
                        //string OldFilePath = Path.Combine(_WebhostEnvironment.WebRootPath, villa.ImageUrl.TrimStart('\\'));

                       
                        using var filestram = new FileStream(Path.Combine(ImagePath, FileName), FileMode.Create);
                        villa.Image.CopyTo(filestram);
                        villa.ImageUrl = @"Images\Villa\" + FileName;
                    }
                }
                _unitOfWork.villa.Update(villa);
                _unitOfWork.Save();
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
                    _unitOfWork.Save();
                    var imagepath = Path.Combine(_WebhostEnvironment.WebRootPath, villa.ImageUrl.TrimStart('\\'));
                    System.IO.File.Delete(imagepath);
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
