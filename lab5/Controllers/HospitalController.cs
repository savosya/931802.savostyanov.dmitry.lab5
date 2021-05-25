using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace lab5.Controllers
{
    public class HospitalController : Controller
    {

        private readonly AppDbContext _appDb;
        public HospitalController(AppDbContext context)
        {
            _appDb = context;
        }
        public async Task<ActionResult> Index()
        {
            
            return View(await _appDb.Hospitals.ToListAsync());
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(HospitalModel model)
        {
            if (ModelState.IsValid)
            {
                _appDb.Hospitals.Add(model);
                await _appDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                HospitalModel hospital = await _appDb.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hospital != null)
                    return View(hospital);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HospitalModel model)
        {
            _appDb.Hospitals.Update(model);
            await _appDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                HospitalModel hospital = await _appDb.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hospital != null)
                    return View(hospital);
            }
            return NotFound();
        }



        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                HospitalModel hospital = await _appDb.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hospital != null)
                    return View(hospital);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                HospitalModel hospital = await _appDb.Hospitals.FirstOrDefaultAsync(p => p.Id == id);
                if (hospital != null)
                {
                    _appDb.Hospitals.Remove(hospital);
                    await _appDb.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
