using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student__management__system.Data;
using Student__management__system.Models;
using Student__management__system.Models;

namespace ClassStudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbcontext _context;

        public StudentController(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Students.Include(s => s.Streams);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["StreamId"] = new SelectList(_context.Streams, "StreamId", "StreamName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,Age,StreamId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StreamId"] = new SelectList(_context.Streams, "StreamId", "StreamName", student.StreamId);
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["StreamId"] = new SelectList(_context.Streams, "StreamId", "StreamName", student.StreamId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,Age,StreamId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["StreamId"] = new SelectList(_context.Streams, "StreamId", "StreamName", student.StreamId);
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Streams)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
