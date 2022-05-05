#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class GuestBookController : Controller
    {
        private readonly MyPortfolioContext _context;




        public GuestBookController(MyPortfolioContext context)
        {
            _context = context;
        }





        // GET: GuestBook
        public async Task<IActionResult> Index()
        {
            return View(await _context.GuestBook.ToListAsync());
        }







        // GET: GuestBook/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestBook = await _context.GuestBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestBook == null)
            {
                return NotFound();
            }

            return View(guestBook);
        }

        // GET: GuestBook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Body,Email,FullName,CreatedAt")] GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guestBook);
        }

        // GET: GuestBook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestBook = await _context.GuestBook.FindAsync(id);
            if (guestBook == null)
            {
                return NotFound();
            }
            return View(guestBook);
        }

        // POST: GuestBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Body,Email,FullName,CreatedAt")] GuestBook guestBook)
        {
            if (id != guestBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestBookExists(guestBook.Id))
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
            return View(guestBook);
        }

        // GET: GuestBook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestBook = await _context.GuestBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guestBook == null)
            {
                return NotFound();
            }

            return View(guestBook);
        }

        // POST: GuestBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestBook = await _context.GuestBook.FindAsync(id);
            _context.GuestBook.Remove(guestBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestBookExists(int id)
        {
            return _context.GuestBook.Any(e => e.Id == id);
        }
    }
}
