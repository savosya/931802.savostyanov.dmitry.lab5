using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace lab5.Controllers
{
    public class LabController : Controller
    {
        private readonly AppDbContext _appDb;
        public LabController(AppDbContext context)
        {
            _appDb = context;
        }
        public async Task<ActionResult> Index()
        {

            return View(await _appDb.Labs.ToListAsync());
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(LabModel model)
        {
            if (ModelState.IsValid)
            {
                _appDb.Labs.Add(model);
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
                LabModel lab = await _appDb.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lab != null)
                    return View(lab);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LabModel model)
        {
            _appDb.Labs.Update(model);
            await _appDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                LabModel lab = await _appDb.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lab != null)
                    return View(lab);
            }
            return NotFound();
        }



        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                LabModel lab = await _appDb.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lab != null)
                    return View(lab);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                LabModel lab = await _appDb.Labs.FirstOrDefaultAsync(p => p.Id == id);
                if (lab != null)
                {
                    _appDb.Labs.Remove(lab);
                    await _appDb.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}

