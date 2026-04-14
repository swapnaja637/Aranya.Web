using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aranya.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDBContext _context;

        public VillaController(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var villas = await _context.Tbl_Villas.ToListAsync();
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
                await _context.AddAsync(villa);
                _context.SaveChanges();
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
            Villa? villa = await _context.Tbl_Villas.FirstOrDefaultAsync(i => i.Id == villaId);
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
                _context.Update(villa);
                _context.SaveChanges();
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
            Villa? villa = await _context.Tbl_Villas.FirstOrDefaultAsync(u => u.Id == Id);
            if (villa != null)
            {

                if (villa.Id != 0)
                {
                    _context.Remove(villa);
                    _context.SaveChanges();
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
