using Booking.Api.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult> IndexAsync()
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalenderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalenderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalenderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
