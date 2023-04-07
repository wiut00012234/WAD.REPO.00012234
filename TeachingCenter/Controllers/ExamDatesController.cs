using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeachingCenter.Data;
using TeachingCenter.Models;

namespace TeachingCenter.Controllers
{
    public class ExamDatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamDatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExamDates
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExamDates.ToListAsync());
        }

        // GET: ExamDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examDate = await _context.ExamDates
                .FirstOrDefaultAsync(m => m.ID == id);
            if (examDate == null)
            {
                return NotFound();
            }

            return View(examDate);
        }

        // GET: ExamDates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamDates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Course,Date,Location,Notes")] ExamDate examDate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examDate);
        }

        // GET: ExamDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examDate = await _context.ExamDates.FindAsync(id);
            if (examDate == null)
            {
                return NotFound();
            }
            return View(examDate);
        }

        // POST: ExamDates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Course,Date,Location,Notes")] ExamDate examDate)
        {
            if (id != examDate.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamDateExists(examDate.ID))
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
            return View(examDate);
        }

        // GET: ExamDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examDate = await _context.ExamDates
                .FirstOrDefaultAsync(m => m.ID == id);
            if (examDate == null)
            {
                return NotFound();
            }

            return View(examDate);
        }

        // POST: ExamDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examDate = await _context.ExamDates.FindAsync(id);
            _context.ExamDates.Remove(examDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamDateExists(int id)
        {
            return _context.ExamDates.Any(e => e.ID == id);
        }
    }
}
