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
    public class MasterController : Controller
    {
        private readonly MasterContext _context;

        public MasterController(MasterContext context)
        {
            _context = context;
        }



        // GET: Master
        public async Task<IActionResult> Index()
        {
            var masters = new List<MasterModel>();
            if(_context.Master != null)
                masters = _context.Master.ToList();
            masters.Sort();
            return View(masters);
              /*return _context.Master != null ? 
                          View(await _context.Master.ToListAsync()) :
                          Problem("Entity set 'MasterContext.Master'  is null.");*/
        }

        public async Task<IActionResult> Woman()
        {
            var masters = new List<MasterModel>();
            if (_context.Master != null)
                masters = _context.Master.ToList();
            masters.Sort();
            return  View(masters);
            /*return _context.Master != null ? 
                        View(await _context.Master.ToListAsync()) :
                        Problem("Entity set 'MasterContext.Master'  is null.");*/
        }
        public async Task<IActionResult> Man()
        {
            var masters = new List<MasterModel>();
            if (_context.Master != null)
                masters = _context.Master.ToList();
            masters.Sort();
            return View(masters);
            /*return _context.Master != null ? 
                        View(await _context.Master.ToListAsync()) :
                        Problem("Entity set 'MasterContext.Master'  is null.");*/
        }
        [HttpGet]
        public async Task<IActionResult> Show(int id, int roomId)
        {
            var masters = _context.Master.Where(m=> m.roomid== roomId).ToList();
            var entry = new HalfEntry()
            {
                masters = masters,
                serviceid = id,
            };
            return View(entry);
        }

        // GET: Master/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Master == null)
            {
                return NotFound();
            }

            var masterModel = await _context.Master
                .FirstOrDefaultAsync(m => m.id == id);
            if (masterModel == null)
            {
                return NotFound();
            }

            return View(masterModel);
        }

        // GET: Master/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,secondname,roomid")] MasterModel masterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masterModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masterModel);
        }

        // GET: Master/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Master == null)
            {
                return NotFound();
            }

            var masterModel = await _context.Master.FindAsync(id);
            if (masterModel == null)
            {
                return NotFound();
            }
            return View(masterModel);
        }

        // POST: Master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,secondname,roomid")] MasterModel masterModel)
        {
            if (id != masterModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masterModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterModelExists(masterModel.id))
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
            return View(masterModel);
        }

        // GET: Master/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Master == null)
            {
                return NotFound();
            }

            var masterModel = await _context.Master
                .FirstOrDefaultAsync(m => m.id == id);
            if (masterModel == null)
            {
                return NotFound();
            }

            return View(masterModel);
        }

        // POST: Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Master == null)
            {
                return Problem("Entity set 'MasterContext.Master'  is null.");
            }
            var masterModel = await _context.Master.FindAsync(id);
            if (masterModel != null)
            {
                _context.Master.Remove(masterModel);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterModelExists(int id)
        {
          return (_context.Master?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
