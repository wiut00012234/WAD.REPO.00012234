﻿using System;
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
    public class EBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.EBooks.ToListAsync());
        }

        // GET: EBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = await _context.EBooks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // GET: EBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Author,Publisher,Description,URL")] EBook eBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eBook);
        }

        // GET: EBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = await _context.EBooks.FindAsync(id);
            if (eBook == null)
            {
                return NotFound();
            }
            return View(eBook);
        }

        // POST: EBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Author,Publisher,Description,URL")] EBook eBook)
        {
            if (id != eBook.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EBookExists(eBook.ID))
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
            return View(eBook);
        }

        // GET: EBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = await _context.EBooks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // POST: EBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eBook = await _context.EBooks.FindAsync(id);
            _context.EBooks.Remove(eBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EBookExists(int id)
        {
            return _context.EBooks.Any(e => e.ID == id);
        }
    }
}
