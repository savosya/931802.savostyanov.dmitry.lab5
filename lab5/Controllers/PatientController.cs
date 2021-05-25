using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace lab5.Controllers
{
    public class PatientController : Controller
    {

        private readonly AppDbContext _appDb;
        public PatientController(AppDbContext context)
        {
            _appDb = context;
        }
        public async Task<ActionResult> Index()
        {

            return View(await _appDb.Patients.ToListAsync());
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(PatientModel model)
        {
            if (ModelState.IsValid)
            {
                _appDb.Patients.Add(model);
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
                PatientModel pat = await _appDb.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                    return View(pat);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PatientModel model)
        {
            _appDb.Patients.Update(model);
            await _appDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                PatientModel pat = await _appDb.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                    return View(pat);
            }
            return NotFound();
        }



        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                PatientModel pat = await _appDb.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                    return View(pat);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                PatientModel pat = await _appDb.Patients.FirstOrDefaultAsync(p => p.Id == id);
                if (pat != null)
                {
                    _appDb.Patients.Remove(pat);
                    await _appDb.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
