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
    public class ServiceController : Controller
    {
        private readonly ServiceContext _context;

        public ServiceController(ServiceContext context)
        {
            _context = context;
        }

       

        // GET: Service
        public async Task<IActionResult> Index()
        {
            var list = _context.Service.ToList();
            list.Sort();
            return _context.Service != null ? 
                          View(list) :
                          Problem("Entity set 'ServiceContext.Service'  is null.");
        }
        public async Task<IActionResult> Woman()
        {
            var list = _context.Service.ToList();
            list.Sort();
            return _context.Service != null ?
                          View(list) :
                          Problem("Entity set 'ServiceContext.Service'  is null.");
        }
        public async Task<IActionResult> Man()
        {
            var list = _context.Service.ToList();
            list.Sort();
            return _context.Service != null ?
                          View(list) :
                          Problem("Entity set 'ServiceContext.Service'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Card(int id)
        {
            if (id == 0 || _context.Service == null)
                return NotFound();
            var service = await _context.Service.FirstOrDefaultAsync(m => m.id == id);
            if (service == null) return NotFound();
            return View(service);
        }
        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Service
                .FirstOrDefaultAsync(m => m.id == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,cost,roomId")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceModel);
        }

        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Service.FindAsync(id);
            if (serviceModel == null)
            {
                return NotFound();
            }
            return View(serviceModel);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,cost,roomId")] ServiceModel serviceModel)
        {
            if (id != serviceModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceModelExists(serviceModel.id))
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
            return View(serviceModel);
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Service
                .FirstOrDefaultAsync(m => m.id == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Service == null)
            {
                return Problem("Entity set 'ServiceContext.Service'  is null.");
            }
            var serviceModel = await _context.Service.FindAsync(id);
            if (serviceModel != null)
            {
                _context.Service.Remove(serviceModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceModelExists(int id)
        {
          return (_context.Service?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
