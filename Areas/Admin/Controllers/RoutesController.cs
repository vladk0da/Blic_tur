using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blic_tur.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Blic_tur.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoutesController : Controller
    {
        private readonly BlicTourContext _context;
        private readonly IHostingEnvironment _env;

        public RoutesController(BlicTourContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Routes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Routes
                                      .Include(r => r.CityFrom)
                                      .Include(r => r.CityTo).ToListAsync());
        }

        // GET: Admin/Routes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Admin/Routes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Cities"] = (await _context.Cities.ToListAsync()).ConvertAll(c => new SelectListItem { Text=c.Title, Value=c.Id.ToString() });
            return View();
        }

        // POST: Admin/Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RouteViewModel routeViewModel, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    var fileName = Path.Combine(_env.WebRootPath, "uploads", Path.GetFileName(picture.FileName));
                    picture.CopyTo(new FileStream(fileName, FileMode.Create));
                }
                var route = new Route
                {
                    Price = routeViewModel.Price,
                    Description = routeViewModel.Description,
                    CityFrom = await _context.Cities.FindAsync(routeViewModel.CityFromId),
                    CityTo = await _context.Cities.FindAsync(routeViewModel.CityToId),
                    Img = picture.FileName
                };
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cities"] = (await _context.Cities.ToListAsync()).ConvertAll(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString() });
            return View(routeViewModel);
        }

        // GET: Admin/Routes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            ViewData["Cities"] = (await _context.Cities.ToListAsync()).ConvertAll(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString() });
            return View(route);
        }

        // POST: Admin/Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Route route
        public async Task<IActionResult> Edit(Guid id, RouteViewModel routeViewModel, IFormFile picture, string oldPicture)
        {
            if (id != routeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (picture != null)
                    {
                        var fileName = Path.Combine(_env.WebRootPath, "uploads", Path.GetFileName(picture.FileName));
                        picture.CopyTo(new FileStream(fileName, FileMode.Create));
                    }
                    var route = new Route
                    {
                        Id = routeViewModel.Id,
                        Price = routeViewModel.Price,
                        Description = routeViewModel.Description,
                        CityFrom = await _context.Cities.FindAsync(routeViewModel.CityFromId),
                        CityTo = await _context.Cities.FindAsync(routeViewModel.CityToId),
                        Img = picture != null ? picture.FileName : oldPicture
                    };
                    _context.Attach(route);
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(routeViewModel.Id))
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
            ViewData["Cities"] = (await _context.Cities.ToListAsync()).ConvertAll(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString() });
            return View(routeViewModel);
        }

        // GET: Admin/Routes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Admin/Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var route = await _context.Routes.FindAsync(id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(Guid id)
        {
            return _context.Routes.Any(e => e.Id == id);
        }
    }
}
