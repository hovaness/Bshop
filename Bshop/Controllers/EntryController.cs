using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bshop.Entity;
using Bshop.Models;

namespace Bshop.Controllers
{
    public class EntryController : Controller
    {
        private readonly EntryContext _context;

        public EntryController(EntryContext context)
        {
            _context = context;
        }

        // GET: Entry
        public async Task<IActionResult> Index()
        {
              return _context.Entrys != null ? 
                          View(await _context.Entrys.ToListAsync()) :
                          Problem("Entity set 'EntryContext.Entrys'  is null.");
        }

        // GET: Entry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entrys == null)
            {
                return NotFound();
            }

            var entryModel = await _context.Entrys
                .FirstOrDefaultAsync(m => m.id == id);
            if (entryModel == null)
            {
                return NotFound();
            }

            return View(entryModel);
        }
        [HttpGet]
        public IActionResult Add(int masterId,int serviceId)
        {
            var entry = new EntryModel
            {
                masterid = masterId,
                serviceid = serviceId,
            };
            return View(entry);
        }

        // GET: Entry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,clientid,masterid,serviceid,time")] EntryModel entryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entryModel);
        }

        // GET: Entry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entrys == null)
            {
                return NotFound();
            }

            var entryModel = await _context.Entrys.FindAsync(id);
            if (entryModel == null)
            {
                return NotFound();
            }
            return View(entryModel);
        }

        // POST: Entry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,clientid,masterid,serviceid,time")] EntryModel entryModel)
        {
            if (id != entryModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryModelExists(entryModel.id))
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
            return View(entryModel);
        }

        // GET: Entry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entrys == null)
            {
                return NotFound();
            }

            var entryModel = await _context.Entrys
                .FirstOrDefaultAsync(m => m.id == id);
            if (entryModel == null)
            {
                return NotFound();
            }

            return View(entryModel);
        }

        // POST: Entry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entrys == null)
            {
                return Problem("Entity set 'EntryContext.Entrys'  is null.");
            }
            var entryModel = await _context.Entrys.FindAsync(id);
            if (entryModel != null)
            {
                _context.Entrys.Remove(entryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryModelExists(int id)
        {
          return (_context.Entrys?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
