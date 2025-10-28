using Microsoft.AspNetCore.Mvc;
using SmartTech_Store.Datacon;
using SmartTech_Store.Filters;
using SmartTech_Store.Models;

namespace SmartTech_Store.Controllers
{
    [SessionAuthorize]
    public class BrandController : Controller
    {
        private readonly majedDbContext _context;

        public BrandController(majedDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Brand> data = _context.Brands.ToList();
                return View(data);
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
        public IActionResult Create(Brand category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }

                _context.Brands.Add(category);
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
            var data = _context.Brands.Find(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(brand);
                }

                _context.Brands.Update(brand);
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
            var data = _context.Brands.Find(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Brand brand)
        {
            try
            {

                _context.Brands.Remove(brand);
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
