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
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly ILogger<VillaNumberController> _logger;
        public VillaNumberController(IUnitOfWork unitOfWork, ILogger<VillaNumberController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Fetching villa numbers from the database.");
                var villaNumber = await _unitOfWork.villaNumber.GetAllAsync(includeproperties: "villa");
                //  var vn = await _unitOfWork.Tbl_VillaNumber.Include(u => u.VillaID).ToListAsync();    
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
               var villas = await _unitOfWork.villa.GetAllAsync();

                VMVillaNumber vmVillanumber = new()
                {
                    villaList = villas.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }).ToList()
                };
                //var villas = await _unitOfWork.Tbl_Villas.ToListAsync();
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
                var villas = await _unitOfWork.villa.GetAllAsync(); 
                // VillaNumber? villnum = vmvillaNumber.villaNumber;
                bool existingVillaNumber = await _unitOfWork.villaNumber.Any(u => u.Villa_Number == vmvillaNumber.villaNumber.Villa_Number);
                // ModelState.Remove("Villa");
                if (ModelState.IsValid && !existingVillaNumber)
                {
                    //VillaNumber? existingVillaNumber = await _unitOfWork.Tbl_VillaNumber.FirstAsync(u => u.Villa_Number == vmvillaNumber.Villa_Number);

                    //if (existingVillaNumber !=)
                    //{
                    //    _logger.LogInformation("Villa number" + vmvillaNumber.Villa_Number + " already present");
                    //    TempData["error"] = "Villa number" + vmvillaNumber.Villa_Number + " already present";
                    //    return RedirectToAction("Create");
                    //}
                    //else
                    //{
                    _logger.LogInformation("Adding a new villa number to the database.");
                    _unitOfWork.villaNumber.Add(vmvillaNumber.villaNumber);
                     _unitOfWork.villaNumber.Save();
                    TempData["success"] = "Record added successfully.";
                    return RedirectToAction(nameof(Index));
                    // }

                }
                else
                {
                    vmvillaNumber.villaList =  villas.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }).ToList();
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
                var villaNum = await _unitOfWork.villaNumber.GetAsync(i => i.Villa_Number == villaNumberId);
                var villas = await _unitOfWork.villa.GetAllAsync();
                VMVillaNumber vmVillanumber = new()
                {
                    villaList =  villas.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }).ToList(),
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
               await _unitOfWork.villaNumber.update(villanumber);
               await _unitOfWork.Save();
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
                var villa = await _unitOfWork.villaNumber.GetAsync(u=>u.Villa_Number==Id);
                _unitOfWork.villaNumber.Delete(villa);
                await  _unitOfWork.Save();
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
