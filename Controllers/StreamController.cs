using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student__management__system.Data;
using Student__management__system.Models;
namespace Student__management__system.Controllers
{
    public class StreamController : Controller
    {
        private readonly AppDbcontext _context;

        public StreamController(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Streams.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreamId,StreamName,Description")] Stream stream)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stream);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stream);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stream = await _context.Streams.FindAsync(id);
            if (stream == null)
            {
                return NotFound();
            }
            return View(stream);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StreamId,StreamName,Description")] Streams stream)
        {
            if (id != stream.StreamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreamExists(stream.StreamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stream);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stream = await _context.Streams
                .FirstOrDefaultAsync(m => m.StreamId == id);
            if (stream == null)
            {
                return NotFound();
            }

            return View(stream);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stream = await _context.Streams.FindAsync(id);
            _context.Streams.Remove(stream);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreamExists(int id)
        {
            return _context.Streams.Any(e => e.StreamId == id);
        }
    }
}
