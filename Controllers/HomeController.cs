using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blic_tur.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blic_tur.Areas.Admin.ViewModels;

namespace Blic_tur.Controllers
{
    public class HomeController : Controller
    {
        BlicTourContext _db;

        public HomeController(BlicTourContext context)
        {

            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Routes.Include("CityFrom").Include("CityTo").ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> Price()
        {
            return View(await _db.Routes.Include("CityFrom").Include("CityTo").ToListAsync());
        }

        public IActionResult Sucsess()
        {
            return View();
        }

        public async Task<string> ShortOrder(ShortOrderViewModels shortOrderViewModels)
        {
            var newOrder = new Order
            {
                DepartureDate = DateTime.Now,
                Name = shortOrderViewModels.Name,
                Phone = shortOrderViewModels.Phone,
                Comment = shortOrderViewModels.Comment,
                RouteId = new Guid(shortOrderViewModels.RouteId),
                Route = await _db.Routes.FirstOrDefaultAsync(r => r.Id.ToString() == shortOrderViewModels.RouteId)
            };
            _db.Orders.Add(newOrder);
            await _db.SaveChangesAsync();
            return "ok";
        }

        public async Task<IActionResult> ExtendedOrder()
        {
            ViewData["Cities"] = (await _db.Cities.ToListAsync()).ConvertAll(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString() });
            ViewData["Routes"] = await _db.Routes.Include("CityFrom").Include("CityTo").ToListAsync();
            //return View(new ExtendedOrdersViewModels {
            //    DepartureDate = DateTime.Now,
            //    Phone="0991234567",
            //    Comment="Comment",
            //    Amount=1,
            //    FromCity=(await _db.Cities.FirstOrDefaultAsync(c => c.Title=="Днепр")).Id.ToString(),
            //    ToCity = (await _db.Cities.FirstOrDefaultAsync(c => c.Title == "Харьков")).Id.ToString(),
            //    Name ="Коля",
            //    FromPlaceInCity = "пл.Островского",
            //    ToPlaceInCity ="пл. Освобождения"
            //});
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExtendedOrder(ExtendedOrdersViewModels extendedOrdersViewModels)
        {
            if (ModelState.IsValid)
            {
              
                var SearchRouteName = await _db.Routes.FirstOrDefaultAsync(r => r.CityFrom.Id.ToString() == extendedOrdersViewModels.FromCity && r.CityTo.Id.ToString() == extendedOrdersViewModels.ToCity);
                var newOrder = new Order
                {
                    Id = Guid.NewGuid(),
                    Name = extendedOrdersViewModels.Name,
                    Phone = extendedOrdersViewModels.Phone,
                    Amount = extendedOrdersViewModels.Amount,
                    FromPlaceInCity = extendedOrdersViewModels.FromPlaceInCity,
                    ToPlaceInCity = extendedOrdersViewModels.ToPlaceInCity,
                    DepartureDate = extendedOrdersViewModels.DepartureDate,
                    Comment = extendedOrdersViewModels.Comment,
                    Route = SearchRouteName,
                    RouteId = SearchRouteName.Id
                };
                //_db.Add(newExtendedOrder);
                _db.Add(newOrder);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Sucsess));
            }

            ViewData["Cities"] = (await _db.Cities.ToListAsync()).ConvertAll(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString() });

            return View(extendedOrdersViewModels);
        }

        public async Task<IActionResult> Info(Guid id)
        {
            return View(await _db.Routes.Include("CityFrom").Include("CityTo").FirstOrDefaultAsync(r => r.Id == id));
        }

        [HttpGet]
        public async Task<string> GetPrice(string fromCityId, string toCityId, int amount)
        {
            var route = await _db.Routes.FirstOrDefaultAsync(r => r.CityFromId == new Guid(fromCityId) && r.CityToId == new Guid(toCityId));
            return $"{(((route != null) ? route.Price : 0.0m) * amount)}";
        }

        [HttpGet]
        public async Task<JsonResult> GetCitiesTo(string fromCityId)
        {
            var route = await _db.Routes.Include(r => r.CityTo).Where(r => r.CityFromId == new Guid(fromCityId)).ToListAsync();
            return Json(route.ConvertAll(r => new { r.CityToId, r.CityTo.Title }));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
