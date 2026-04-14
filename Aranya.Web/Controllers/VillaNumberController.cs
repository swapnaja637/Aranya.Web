using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aranya.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<VillaNumberController> _logger;
        public VillaNumberController(ApplicationDBContext context, ILogger<VillaNumberController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Fetching villa numbers from the database.");
                var villaNumber = await _context.Tbl_VillaNumber.ToListAsync();
                return View(villaNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching villa numbers.");
                return RedirectToAction("Error", "Home");
            }

        }
        public async Task<IActionResult> Create()
        {
            try
            {
                var villas = await _context.Tbl_Villas.ToListAsync();
                IEnumerable<SelectListItem> villalist = villas.Select(
                     u => new SelectListItem
                     {
                         Text = u.Name,
                         Value = u.Id.ToString()
                     });
                //ViewData["Villalist"] = villalist;
                ViewBag.villalist = villalist;
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, " Error in Create VillaNumber");
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(VillaNumber villaNumber)
        {
            try
            {
               // ModelState.Remove("Villa");
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Adding a new villa number to the database.");
                    _context.Tbl_VillaNumber.Add(villaNumber);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Record added successfully.";
                    return RedirectToAction("Index");
                }
                return View(villaNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new villa number.");
                TempData["error"] = "Record not added successfully.";
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Update(int villaNumberId)
        {
            try
            {
                _logger.LogInformation("Fetching villa number with ID {VillaNumber} for update.", villaNumberId);
                var villaNum = await _context.Tbl_VillaNumber.FirstOrDefaultAsync(i => i.Villa_Number == villaNumberId);
                if (villaNum == null)
                {
                    _logger.LogWarning("Villa number with ID {VillaNumber} not found.", villaNumberId);
                    return RedirectToAction("Error", "Home");
                }
                return View(villaNum);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the villa number for update.");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
