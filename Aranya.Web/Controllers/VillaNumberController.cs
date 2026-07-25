using Aranya.Application.Generic.Interfaces;
using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using Aranya.Web.ViewModel;
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
                var villaNumber = await _context.Tbl_VillaNumber.Include(u => u.villa).ToListAsync();
                //  var vn = await _context.Tbl_VillaNumber.Include(u => u.VillaID).ToListAsync();    
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

                VMVillaNumber vmVillanumber = new()
                {
                    villaList = await _context.Tbl_Villas.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }).ToListAsync()
                };
                //var villas = await _context.Tbl_Villas.ToListAsync();
                //IEnumerable<SelectListItem> villalist = villas.Select(
                //     u => new SelectListItem
                //     {
                //         Text = u.Name,
                //         Value = u.Id.ToString()
                //     });

                ////ViewData["Villalist"] = villalist;
                //ViewBag.villalist = villalist;
                return View(vmVillanumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, " Error in Create VillaNumber");
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(VMVillaNumber vmvillaNumber)
        {
            try
            {
                // VillaNumber? villnum = vmvillaNumber.villaNumber;
                bool existingVillaNumber = await _context.Tbl_VillaNumber.AnyAsync(u => u.Villa_Number == vmvillaNumber.villaNumber.Villa_Number);
                // ModelState.Remove("Villa");
                if (ModelState.IsValid && !existingVillaNumber)
                {
                    //VillaNumber? existingVillaNumber = await _context.Tbl_VillaNumber.FirstAsync(u => u.Villa_Number == vmvillaNumber.Villa_Number);

                    //if (existingVillaNumber !=)
                    //{
                    //    _logger.LogInformation("Villa number" + vmvillaNumber.Villa_Number + " already present");
                    //    TempData["error"] = "Villa number" + vmvillaNumber.Villa_Number + " already present";
                    //    return RedirectToAction("Create");
                    //}
                    //else
                    //{
                    _logger.LogInformation("Adding a new villa number to the database.");
                    _context.Tbl_VillaNumber.Add(vmvillaNumber.villaNumber);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Record added successfully.";
                    return RedirectToAction(nameof(Index));
                    // }

                }
                else
                {
                    vmvillaNumber.villaList = await _context.Tbl_Villas.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }).ToListAsync();
                    _logger.LogInformation("Villa number" + vmvillaNumber.villaNumber.Villa_Number + " already present");
                    TempData["error"] = "Villa number" + vmvillaNumber.villaNumber.Villa_Number + " already present";
                    return View(vmvillaNumber);
                }
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
                VMVillaNumber vmVillanumber = new()
                {
                    villaList = await _context.Tbl_Villas.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }).ToListAsync(),
                    villaNumber = villaNum

                };

                if (vmVillanumber == null)
                {
                    _logger.LogWarning("Villa number with ID {VillaNumber} not found.", villaNumberId);
                    return RedirectToAction("Error", "Home");
                }

                return View(vmVillanumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the villa number for update.");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(VMVillaNumber vMVillaNumber)
        {
            try
            {
                _logger.LogInformation("In UpdatePost Method with vmVillaNumber data : " + vMVillaNumber);
                var villanumber = vMVillaNumber.villaNumber;
                _context.Update(villanumber);
               await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in function Update post : " + ex.Message);
                TempData["error"] = "Record not updated successfully.";
                return View(vMVillaNumber);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                _logger.LogInformation("In function Delete post.For villa number" + Id);
                //USE FINDASYNCH FOR PRIMARY KEY AND IF WANT TO DELETE FROM ANOTHER COLUMN THEN USE FIRSTORDEFAULTASYNCH
                var villa = await _context.Tbl_VillaNumber.FindAsync(Id);
                _context.Remove(villa);
                await  _context.SaveChangesAsync();
                TempData["success"] = "Record deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in function Delete. Error : " + ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
