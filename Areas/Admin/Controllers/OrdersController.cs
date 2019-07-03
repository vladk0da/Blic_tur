using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blic_tur.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blic_tur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly BlicTourContext _context;

        public OrdersController(BlicTourContext context)
        {
            _context = context;
        }

        // GET: Admin/Orders
        public async Task<IActionResult> Index()
        {
            var blicTourContext = _context.Orders;
            return View(await blicTourContext.Include(o => o.Route).Include(o => o.Route.CityFrom).Include(o=>o.Route.CityTo).ToListAsync());
        }

        // GET: Admin/Orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                //.Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/Orders/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["Routes"] = (await _context.Routes.Include(r => r.CityFrom).Include(r => r.CityTo).ToListAsync())
                                          .ConvertAll(c => new SelectListItem { Text = $"{c.CityFrom.Title} - {c.CityTo.Title}", Value = c.Id.ToString() });
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Name,Phone,FromPlaceInCity,ToPlaceInCity,DepartureDate,Comment,Route,RouteId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Routes"] = (await _context.Routes.Include(r => r.CityFrom).Include(r => r.CityTo).ToListAsync())
                                         .ConvertAll(c => new SelectListItem { Text = $"{c.CityFrom.Title} - {c.CityTo.Title}", Value = c.Id.ToString() });
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["Routes"] = (await _context.Routes.Include(r => r.CityFrom).Include(r=>r.CityTo).ToListAsync())
                                         .ConvertAll(c => new SelectListItem { Text = $"{c.CityFrom.Title} - {c.CityTo.Title}", Value = c.Id.ToString() });
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["Routes"] = (await _context.Routes.Include(r => r.CityFrom).Include(r => r.CityTo).ToListAsync())
                                         .ConvertAll(c => new SelectListItem { Text = $"{c.CityFrom.Title} - {c.CityTo.Title}", Value = c.Id.ToString() });
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View(order);
        }

        // GET: Admin/Orders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
               // .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(Guid id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
