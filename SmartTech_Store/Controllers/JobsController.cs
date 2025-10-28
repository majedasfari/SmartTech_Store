using Microsoft.AspNetCore.Mvc;
using SmartTech_Store.Datacon;
using SmartTech_Store.Filters;
using SmartTech_Store.Models;

namespace SmartTech_Store.Controllers
{
    [SessionAuthorize]
    public class JobsController : Controller
    {
        private readonly majedDbContext _context;

        public JobsController(majedDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Job> Jobs = _context.Jobs.ToList();
                return View(Jobs);
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(job);
                }

                _context.Jobs.Add(job);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }


        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var job = _context.Jobs.Find(Id);
            return View(job);
        }

        [HttpPost]
        public IActionResult Edit(Job job)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(job);
                }

                _context.Jobs.Update(job);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }


        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var job = _context.Jobs.Find(Id);
            return View(job);
        }

        [HttpPost]
        public IActionResult Delete(Job job)
        {
            try
            {

                _context.Jobs.Remove(job);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }


        }
    }
}
