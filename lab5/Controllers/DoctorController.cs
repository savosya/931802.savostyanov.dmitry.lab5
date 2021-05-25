using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Controllers
{
    public class DoctorController : Controller
    {

        private readonly AppDbContext _appDb;
        public DoctorController(AppDbContext context)
        {
            _appDb = context;
        }
        public async Task<ActionResult> Index()
        {

            return View(await _appDb.Doctors.ToListAsync());
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.hospitals = await _appDb.Hospitals.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(DoctorModel model)
        {
            List<HospitalModel> hospList = await _appDb.Hospitals.ToListAsync();
            ViewBag.hospitals = hospList;
            //List<HospitalModel> hosp = await _appDb.Hospitals.ToListAsync();
            if (ModelState.IsValid)
            {
                if (hospList.Any())
                {
                    _appDb.Doctors.Add(new DoctorModel
                    {
                        Name = model.Name,
                        Speciality = model.Speciality,
                        HospitalId = model.Id,
                        Hospital = _appDb.Hospitals.FirstOrDefault(h => h.Id == model.Id)
                    });
                    await _appDb.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("hosp", "The Hospital field is required.");
            }     
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                DoctorModel doc = await _appDb.Doctors.FirstOrDefaultAsync(p => p.Id == id);             
                if (doc != null)
                {
                    ViewBag.hospitals = await _appDb.Hospitals.ToListAsync();
                    return View(doc);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DoctorModel model)
        {
            _appDb.Doctors.Update(model);
            await _appDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                DoctorModel doc = await _appDb.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                
                if (doc != null)
                {
                    HospitalModel hosp = await _appDb.Hospitals.FirstOrDefaultAsync(h => h.Id == doc.HospitalId);

                    if (hosp == null)
                        ViewBag.hName = "Unknown";
                    else
                        ViewBag.hName = hosp.Name;
                    return View(doc);       
                }
                    
            }
            return NotFound();
        }



        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                DoctorModel doc = await _appDb.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                if (doc != null)
                    return View(doc);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                DoctorModel doc = await _appDb.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                if (doc != null)
                {
                    _appDb.Doctors.Remove(doc);
                    await _appDb.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }

}

