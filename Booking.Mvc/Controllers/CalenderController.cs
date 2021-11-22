using System;
using Booking.Api.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Booking.Api.Contract.Dto;

namespace Booking.Mvc.Controllers
{
    public class CalenderController : Controller
    {
        private ICalenderService _calenderService;

        public CalenderController(ICalenderService calenderService)
        {
            _calenderService = calenderService;
        }
        // GET: CalenderController
        public async Task<ActionResult> Index()
        {
            var model = await _calenderService.GetCalendarsAsync();
            //var viewMode = _mapper<CalenderViewModel>(model); // Automapper
            return View(model);
        }

        // GET: CalenderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalenderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalenderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CalendarDto calendar)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(course);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendar);
        }

        // GET: CalenderController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _calenderService.GetCalendarByIdAsync(id);

            return View(model);
        }

        // POST: CalenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, CalendarDto calendar)
        {
            if (id != calendar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(course);
                    //await _context.SaveChangesAsync();
                }
                catch (Exception e)//(DbUpdateConcurrencyException)
                {
                    //if (!CourseExists(course.CourseId))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calendar);
        }

        // GET: CalenderController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: CalenderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, CalendarDto calendar)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
